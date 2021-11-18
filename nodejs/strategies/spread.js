import axios from 'axios'

const TOKEN_URL = '<TOKEN_URL>'
const BASE_ADDRESS = '<BASE_ADDRESS>'
const BROKER = '<YOUR_BROKER>'   // Ex: '123'
const ACCOUNT = '<YOUR_ACCOUNT>' // Ex: '321'

// Token auth params
const data = {
    grant_type: 'password', // do not change
    scope: 'externalapi',   // do not change
    username: '<USERNAME>',
    password: '<PASSWORD>',
    client_id: '<CLIENT_ID>',
    client_secret: '<CLIENT_SECRET>'
}
}

async function getToken() {
    let token;
    const query = new URLSearchParams(data);
    await axios.post(TOKEN_URL, query.toString())
        .then(response => {
            console.log('GOT THE TOKEN');
            token = response.data.access_token;
        }).catch(error => console.log('ERROR WHILE TRYING TO GET THE TOKEN: ' + error));

    return token;
}

async function createSpread(headers, newRequest) {
    let strategyId;
    await axios.post(BASE_ADDRESS, newRequest, { headers: headers })
        .then(response => {
            console.log(response.data);
            console.log();

            strategyId = response.data.StrategyId;
        }).catch(error => console.log('Error: ' + error));
    return strategyId;
}

async function updateSpread(headers, updateRequest, strategyId) {
    await axios.put(`${BASE_ADDRESS}/${strategyId}`, updateRequest, { headers })
        .then(response => {
            console.log(response.data);
            console.log();
        }).catch(error => console.log('Error: ' + error));
}

async function cancelSpread(headers, strategyId) {
    await axios.delete(`${BASE_ADDRESS}/${strategyId}`, { headers })
        .then(response => {
            console.log(response.data);
            console.log();
        }).catch(error => console.log('Error: ' + error));
}

async function getAllSpreads(headers) {
    await axios.get(BASE_ADDRESS, { headers })
        .then(response => {
            response.data.forEach(order => {
                console.info(JSON.stringify(order));
                console.info();
            })
        }).catch(error => console.log('Error: ' + error));
}

async function getSpreadById(headers, strategyId) {
    let spreadOrder;
    await axios.get(`${BASE_ADDRESS}/${strategyId}`, { headers })
        .then(response => {
            console.log('ORDER: ' + response);
            spreadOrder = response;
        })
        .catch(error => console.log('Error: ' + error));
    return spreadOrder;
}

function isUpdatable(status) {
    return status != 'CANCELLED'
        && status != 'TOTALLY_EXECUTED'
        && status != 'FINISHED'
}

async function run() {
    const accessToken = await getToken()

    const headers = {
        'Authorization': 'Bearer ' + accessToken,
        'Content-Type': 'application/json'
    }

    const newRequest = {
        "Broker": BROKER,
        "Account": ACCOUNT,
        "SpreadValue": 1,
        "SpreadType": "BUY_MINUS_SELL",
        "DifferentialType": "NONE",
        "QuantityType": "QUANTITY",
        "StartTime": "10:00",
        "EndTime": "23:00",
        "WaitTime": 0,
        "MaxSlippageQuantity": 0,
        "SlippageMode": "KEEP_ORDERS",
        "Instruments": [{
            "Symbol": "SULA11",
            "Side": "BUY",
            "Quantity": 1000,
            "MaxDisplayQuantity": 10000,
            "SimultaneousOrders": 3,
            "PriceFactor": 1,
            "Depth": -1,
            "Placement": true,
            "AllowExecution": true
        }, {
            "Symbol": "GOLL4",
            "Side": "SELL",
            "Quantity": 1000,
            "MaxDisplayQuantity": 10000,
            "SimultaneousOrders": 3,
            "PriceFactor": 1,
            "Depth": -1,
            "Placement": true,
            "AllowExecution": true
        }]
    }
    console.log('*** CREATING NEW SPREAD ***');
    const strategyId = await createSpread(headers, newRequest);
    await new Promise(r => setTimeout(r, 3000));

    console.log('*** GETTING ALL SPREADS ***');
    await getAllSpreads(headers);
    await new Promise(r => setTimeout(r, 3000));

    console.log('*** GETTING SPREAD BY ID ***');
    const spread = await getSpreadById(headers, strategyId);
    const status = spread.Status;
    await new Promise(r => setTimeout(r, 3000));

    const updateRequest = {
        "SpreadValue": -6.3325,
        "StopTime": "23:00",
        "EndTime": "23:39",
        "Instruments": [{
            "Quantity": 3100,
            "MaxDisplayQuantity": 500,
            "SimultaneousOrders": 4
        }, {
            "Quantity": 5200,
            "MaxDisplayQuantity": 400,
            "SimultaneousOrders": 4
        }]
    }

    if (isUpdatable(status)) {
        console.log('*** UPDATING SPREAD ***');
        await updateSpread(headers, updateRequest, strategyId);
        await new Promise(r => setTimeout(r, 3000));

        console.log('*** CANCELLING SPREAD ***');
        await cancelSpread(headers, strategyId);
        await new Promise(r => setTimeout(r, 3000));
    } else {
        console.log('It was not possible to Update/Cancel the spread, since the current status is: ' + status);
    }
}

run()
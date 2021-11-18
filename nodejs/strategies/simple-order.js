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

async function createSimpleOrder(headers, newRequest) {
    let strategyId;
    await axios.post(BASE_ADDRESS, newRequest, { headers: headers })
        .then(response => {
            console.log(response.data);
            console.log();

            strategyId = response.data.StrategyId;
        }).catch(error => console.log('Error: ' + error));
    return strategyId;
}

async function updateSimpleOrder(headers, updateRequest, strategyId) {
    await axios.put(`${BASE_ADDRESS}/${strategyId}`, updateRequest, { headers })
        .then(response => {
            console.log(response.data);
            console.log();
        }).catch(error => console.log('Error: ' + error));
}

async function cancelSimpleOrder(headers, strategyId) {
    await axios.delete(`${BASE_ADDRESS}/${strategyId}`, { headers })
        .then(response => {
            console.log(response.data);
            console.log();
        }).catch(error => console.log('Error: ' + error));
}

async function getAllSimpleOrders(headers) {
    await axios.get(BASE_ADDRESS, { headers })
        .then(response => {
            response.data.forEach(order => {
                console.info(JSON.stringify(order));
                console.info();
            })
        }).catch(error => console.log('Error: ' + error));
}

async function getSimpleOrderById(headers, strategyId) {
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
        'Broker': BROKER,
        'Account': ACCOUNT,
        'OrderType': 'LIMIT',
        'Symbol': 'BBSE3',
        'Side': 'BUY',
        'Quantity': 1000,
        'TimeInForce': 'DAY',
        'Price': 20.04
    }
    console.log('*** CREATING NEW SIMPLE ORDER ***');
    const strategyId = await createSimpleOrder(headers, newRequest);
    await new Promise(r => setTimeout(r, 3000));

    console.log('*** GETTING ALL SIMPLE ORDERS ***');
    await getAllSimpleOrders(headers);
    await new Promise(r => setTimeout(r, 3000));

    console.log('*** GETTING SIMPLE ORDER BY ID ***');
    const simpleOrder = await getSimpleOrderById(headers, strategyId)
    const status = simpleOrder.Status;
    await new Promise(r => setTimeout(r, 3000));

    const updateRequest = {
        'Quantity': 20000
    }

    if (isUpdatable(status)) {
        console.log('*** UPDATING SIMPLE ORDER ***');
        await updateSimpleOrder(headers, updateRequest, strategyId)
        await new Promise(r => setTimeout(r, 3000));

        console.log('*** CANCELLING SIMPLE ORDER ***');
        await cancelSimpleOrder(headers, strategyId)
        await new Promise(r => setTimeout(r, 3000));
    } else {
        console.log('It was not possible to Update/Cancel the spread, since the current status is: ' + status);
    }
}

run()
import axios from 'axios'
import queryString from 'querystring'

const TOKEN_URL = 'https://mtbserver-staging.americastg.com.br:51525/connect/token'
const BASE_ADDRESS = 'https://mtbserver-staging.americastg.com.br:51511/api/spread'
const BROKER = 'sua_corretora' // Ex: '123'
const ACCOUNT = 'sua_conta' // Ex: '321'

// Parâmetros usados para a autenticação do token
const data = {
    grant_type: 'password', // não mudar
    scope: 'externalapi', // não mudar
    username: 'seu_usuário',
    password: 'sua_senha',
    client_id: 'seu_client_id',
    client_secret: 'seu_client_secret'
}

async function getToken() {
    const response = await axios.post(TOKEN_URL, queryString.stringify(data))
        .catch(error => console.log('Erro ao pegar o token: ' + error))
    console.log('TOKEN OBTIDO \n')
    return response.data.access_token
}

async function createSpread(headers, newRequest) {
    const response = await axios.post(BASE_ADDRESS, newRequest, { headers: headers })
        .catch(error => console.log('Erro na inclusão do spread: ' + error))
    console.log('SPREAD CRIADO')
    console.log(response.data, '\n')
    return response
}

async function updateSpread(headers, updateRequest, strategyId) {
    const response = await axios.put(`${BASE_ADDRESS}/${strategyId}`, updateRequest, { headers })
        .catch(error => console.log('Erro na atualização do spread: ' + error))
    console.log('SPREAD ATUALIZADO')
    console.log(response.data, '\n')
}

async function cancelSpread(headers, strategyId) {
    const response = await axios.delete(`${BASE_ADDRESS}/${strategyId}`, { headers })
        .catch(error => console.log('Erro no cancelamento do spread: ' + error))
    console.log('SPREAD CANCELADO')
    console.log(response.data, '\n')
}

async function getAllSpreads(headers) {
    const response = await axios.get(BASE_ADDRESS, { headers })
        .catch(error => console.log('Erro na consulta dos spreads: ' + error))
    console.log('CONSULTA DOS SPREADS')
    response.data.forEach(order => {
        console.info(JSON.stringify(order))
    })
}

async function getLastSpreadStatusById(headers, strategyId) {
    const response = await axios.get(BASE_ADDRESS, { headers })
        .catch(error => console.log('Erro na consulta dos spreads para verificar o status. Erro: ' + error))

    for (let resp of response.data) {
        if (resp['StrategyId'] == strategyId) {
            return resp['Status']
        }
    }
}

async function isUpdatable(status) {
    if (status == 'CANCELLED' ||
        status == 'TOTALLY_EXECUTED' ||
        status == 'FINISHED')
        return false

    return true
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
    const spreadCreationResponse = await createSpread(headers, newRequest)
    const strategyId = spreadCreationResponse.data['StrategyId']

    const status = await getLastSpreadStatusById(headers, strategyId)

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
        await updateSpread(headers, updateRequest, strategyId)

        await cancelSpread(headers, strategyId)
    } else {
        console.log('Não foi possível fazer update/cancelamento da estratégia. Status: ' + status)
    }

    await getAllSpreads(headers)
}

run()
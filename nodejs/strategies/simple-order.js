import axios from 'axios'
import queryString from 'querystring'

const TOKEN_URL = 'https://mtbserver-staging.americastg.com.br:51525/connect/token'
const BASE_ADDRESS = 'https://mtbserver-staging.americastg.com.br:51511/api/simple-order'
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
        .then(console.log('TOKEN OBTIDO \n'))
        .catch(error => console.log('Erro ao pegar o token: ' + error))
    return response.data.access_token
}

async function createSimpleOrder(headers, newRequest) {
    const response = await axios.post(BASE_ADDRESS, newRequest, { headers: headers })
        .catch(error => console.log('Erro na inclusão da ordem simples: ' + error))
    console.log('ORDEM SIMPLES CRIADA')
    console.log(response.data, '\n')
    return response
}

async function updateSimpleOrder(headers, updateRequest, strategyId) {
    const response = await axios.put(`${BASE_ADDRESS}/${strategyId}`, updateRequest, { headers })
        .catch(error => console.log('Erro na atualização da ordem simples: ' + error))
    console.log('ORDERM SIMPLES ATUALIZADA')
    console.log(response.data, '\n')
}

async function cancelSimpleOrder(headers, strategyId) {
    const response = await axios.delete(`${BASE_ADDRESS}/${strategyId}`, { headers })
        .catch(error => console.log('Erro no cancelamento da ordem simples: ' + error))
    console.log('ORDEM SIMPLES CANCELADA')
    console.log(response.data, '\n')
}

async function getAllSimpleOrders(headers) {
    const response = await axios.get(BASE_ADDRESS, { headers })
        .catch(error => console.log('Erro na consulta das ordens simples: ' + error))
    console.log('CONSULTA DAS ORDENS SIMPLES')
    response.data.forEach(order => {
        console.info(JSON.stringify(order))
    })
}

async function getLastSimpleOrderStatusById(headers, strategyId) {
    const response = await axios.get(BASE_ADDRESS, { headers })
        .catch(error => console.log('Erro na consulta das ordens simples para verificar o status. Erro: ' + error))

    for (let resp of response.data) {
        if (resp.StrategyId == strategyId) {
            return resp.Status
        }
    }
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
    const simpleOrderCrationResponse = await createSimpleOrder(headers, newRequest)
    const strategyId = simpleOrderCrationResponse.data.StrategyId

    const status = await getLastSimpleOrderStatusById(headers, strategyId)

    const updateRequest = {
        'Quantity': 20000
    }

    if (isUpdatable(status)) {
        await updateSimpleOrder(headers, updateRequest, strategyId)

        await cancelSimpleOrder(headers, strategyId)
    } else {
        console.log('Não foi possível fazer update/cancelamento da ordem. Status: ' + status)
    }

    await getAllSimpleOrders(headers)
}

run()
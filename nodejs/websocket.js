const msgpck = require("@msgpack/msgpack");
const websocket = require('ws').WebSocket;
const axios = require('axios').default;

const TOKEN_URL = '<TOKEN_URL>/connect/token'
const BASE_ADDRESS = '<BASE_ADDRESS>/api/ws/strategies'

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

async function run() {
    const token = await getToken()
    const ws = new websocket(BASE_ADDRESS.replace('http','ws'));

    ws.onopen = (event) => {
        ws.send(token);
    };

    ws.onmessage = (event) => {
        if(event.data[0] == 0xFF)
        {
            ws.send(0xFF)
            return;
        }
        const strategy = msgpck.decode(event.data);
        console.log('WebSocket message',strategy);
    };

    ws.onerror = (event) => {
        console.log('Error')
        console.log(event.data)
    }
}

run()

import requests
import spread_client

TOKEN_URL = 'https://mtbserver-staging.americastg.com.br:51525/connect/token'
BROKER = 'sua_corretora' # Ex: '321'
ACCOUNT = 'sua_conta' # Ex: '123'

# payload para obter o token
token_request = {
    'grant_type': 'password', # não alterar
    'scope': 'externalapi', # não alterar
    'username': 'seu_usuario',
    'password': 'sua_senha',
    'client_id': 'seu_client_id',
    'client_secret': 'seu_client_secret'
}

# endpoint e request
resp = requests.post(TOKEN_URL, data=token_request)
resp.raise_for_status()
print('Token obtido com sucesso')
print()

# acessando e visualizando o token
access_token = resp.json()['access_token']
headers = {
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + access_token
}

new_request = {
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
        "Placement": True,
        "AllowExecution": True
    }, {
        "Symbol": "GOLL4",
        "Side": "SELL",
        "Quantity": 1000,
        "MaxDisplayQuantity": 10000,
        "SimultaneousOrders": 3,
        "PriceFactor": 1,
        "Depth": -1,
        "Placement": True,
        "AllowExecution": True
    }]
}

update_request = {
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


def main():
    client = spread_client.SpreadClient(headers)

    print('POST REQUEST:')
    response = client.new(new_request)
    print(response.text)
    print()

    strategy_id = response.json()['StrategyId']

    if (client.is_strategy_updatable(strategy_id)):
        print('PUT REQUEST:')
        response = client.update(update_request, strategy_id)
        print(response.text)
        print()

        print('DELETE REQUEST:')
        response = client.cancel(strategy_id)
        print(response.text)
        print()

    print('GET REQUEST:')
    response = client.get()
    print(response.text)


main()

import requests
import simple_order_client

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
    'Broker': BROKER,
    'Account': ACCOUNT,
    'OrderType': 'LIMIT',
    'Symbol': 'BBSE3',
    'Side': 'BUY',
    'Quantity': 1000,
    'TimeInForce': 'DAY',
    'Price': 20.04
}

update_request = {
    'Quantity': 20000
}


def main():
    client = simple_order_client.SimpleOrderClient(headers)

    print('POST REQUEST:')
    response = client.new(new_request)
    print(response.text)
    print()

    strategy_id = response.json()['StrategyId']

    if (client.is_order_updatable(strategy_id)):
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

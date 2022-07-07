from base_client import *

BROKER = '<BROKER>'   # Ex: '321'
ACCOUNT = '<ACCOUNT>' # Ex: '123'

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

    access_token = get_token()
    headers = {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + access_token
    }

    client = BaseClient(headers, 'simple-order')

    print('*** CREATING SIMPLE ORDER ***')
    response = client.new(new_request)
    print(response.text)
    print()

    strategy_id = response.json()['StrategyId']

    print('*** GETTING ALL SIMPLE ORDERS ***')
    response = client.get(0)
    print(response.text)
    print()

    print('*** GETTING SIMPLE ORDER BY ID ***')
    response = client.get_by_id(strategy_id)
    status = response.json()['Status']
    print(response.text)
    print()

    if (client.is_order_updatable(status)):
        print('*** UPDATING SIMPLE ORDER ***')
        response = client.update(update_request, strategy_id)
        print(response.text)
        print()

        print('*** CANCELLING SIMPLE ORDER ***')
        response = client.cancel(strategy_id)
        print(response.text)
        print()

if __name__ == "__main__":
    main()

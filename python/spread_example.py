from base_client import *

BROKER = '<BROKER>'   # Ex: '321'
ACCOUNT = '<ACCOUNT>' # Ex: '123'

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

    access_token = get_token()
    headers = {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + access_token
    }

    client = BaseClient(headers, 'spread')

    print('*** CREATING SPREAD ***')
    response = client.new(new_request)
    print(response.text)
    print()

    strategy_id = response.json()['StrategyId']

    print('*** GETTING ALL SPREADS ***')
    response = client.get(0)
    print(response.text)
    print()

    print('*** GETTING SPREAD BY ID ***')
    response = client.get_by_id(strategy_id)
    status = response.json()['Status']
    print(response.text)
    print()

    if (client.is_order_updatable(status)):
        print('*** UPDATING SPREAD ***')
        response = client.update(update_request, strategy_id)
        print(response.text)
        print()

        print('*** CANCELLING SPREAD ***')
        response = client.cancel(strategy_id)
        print(response.text)
        print()

if __name__ == "__main__":
    main()

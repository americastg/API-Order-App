import json
import requests

BASE_URL = 'https://<URL>/api'
TOKEN_URL = 'https://<URL>/connect/token'

token_request = {
    'grant_type': 'password',  # do not change
    'scope': 'externalapi',    # do not change
    'username': '<USERNAME>',
    'password': '<PASSWORD>',
    'client_id': '<CLIENT_ID>',
    'client_secret': '<CLIENT_SECRET>'
}


def get_token():
    response = requests.post(TOKEN_URL, data=token_request)
    response.raise_for_status()
    return response.json()['access_token']


class BaseClient:
    def __init__(self, headers, endpoint):
        self.headers = headers
        self.endpoint = endpoint

    def get(self):
        response = requests.get(
            f'{BASE_URL}/{self.endpoint}', headers=self.headers)
        response.raise_for_status()
        return response

    def get_by_id(self, strategy_id):
        response = requests.get(
            f'{BASE_URL}/{self.endpoint}/{strategy_id}', headers=self.headers)
        response.raise_for_status()
        return response

    def is_order_updatable(self, status):
        return status != 'CANCELLED' and status != 'FINISHED' and status != 'TOTALLY_EXECUTED'

    def new(self, new_request):
        response = requests.post(f'{BASE_URL}/{self.endpoint}', data=json.dumps(
            new_request), headers=self.headers)
        response.raise_for_status()
        return response

    def update(self, update_request, strategy_id):
        response = requests.put(
            f'{BASE_URL}/{self.endpoint}/{strategy_id}', data=json.dumps(update_request), headers=self.headers)
        response.raise_for_status()
        return response

    def cancel(self, strategy_id):
        response = requests.delete(
            f'{BASE_URL}/{self.endpoint}/{strategy_id}', headers=self.headers)
        response.raise_for_status()
        return response

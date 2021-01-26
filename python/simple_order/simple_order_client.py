import json
import requests

URL = 'https://mtbserver-staging.americastg.com.br:51511/api/simple-order'


class SimpleOrderClient:
    def __init__(self, headers):
        self.headers = headers

    def get(self):
        response = requests.get(URL, headers=self.headers)
        response.raise_for_status()
        return response

    def is_updatable(self):
        response = self.get()
        last_response_in_array = response.json()[-1]
        status = last_response_in_array['Status']
        return status != 'CANCELLED' and status != 'FINISHED' and status != 'TOTALLY_EXECUTED'

    def new(self, new_request):
        response = requests.post(URL, data=json.dumps(
            new_request), headers=self.headers)
        response.raise_for_status()
        return response

    def update(self, update_request, strategy_id):
        response = requests.put(
            f'{URL}/{strategy_id}', data=json.dumps(update_request), headers=self.headers)
        response.raise_for_status()
        return response

    def cancel(self, strategy_id):
        response = requests.delete(
            f'{URL}/{strategy_id}', headers=self.headers)
        response.raise_for_status()
        return response

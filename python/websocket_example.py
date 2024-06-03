import websocket, msgpack, threading
from base_client import *

def on_open(ws):
    token = get_token()
    ws.send(token)

def on_message(ws, message):
    if message == b'\xff':
        ws.send(b'1')
        return
    messageDes = msgpack.unpackb(message)
    print (messageDes)

def on_error(ws, error):
    print("Error:")
    print(error)

def schedule_websocket_heartbeat():
    ws.send(b'1')
    threading.Timer(30.0, schedule_websocket_heartbeat).start()

def main():
    wsUrl = BASE_URL.replace('http','ws')
    websocket.enableTrace(False)
    ws = websocket.WebSocketApp(f'{wsUrl}/ws/strategies',
                                on_open = on_open,
                                on_message = on_message,
                                on_error = on_error
                                )
    ws.on_open = on_open
    schedule_websocket_heartbeat()
    ws.run_forever()

if __name__ == "__main__":
    main()
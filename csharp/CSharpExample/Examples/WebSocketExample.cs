using System.Text;
using System.Net.WebSockets;
using MessagePack;
using CSharpExample.Utils;

namespace CSharpExample.Examples
{
    class WebSocketExample
    {
        private ClientWebSocket _webSocket;
        private readonly string _connection;
        private readonly string _token;
        private readonly byte[] HTB_MSG = new byte[] { 0xFF };

        public WebSocketExample(string connection, string token)
        {
            _connection = connection.Replace("http", "ws");
            _token = token;
        }

        public async Task RunAsync()
        {
            await CreateSocket();

            var disconnectToken = new CancellationTokenSource();
                        
            new Thread(async () => await StartWebSocket(disconnectToken.Token)).Start();
            
            Console.WriteLine("Press any key to close websocket");
            Console.ReadKey();
            disconnectToken.Cancel();
        }

        private async Task CreateSocket()
        {
            _webSocket = new ClientWebSocket();

            await _webSocket.ConnectAsync(new Uri($"{_connection}ws/strategies"), CancellationToken.None);
            var sendBuffer1 = Encoding.UTF8.GetBytes(_token);
            await _webSocket.SendAsync(new ArraySegment<byte>(sendBuffer1), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task StartWebSocket(CancellationToken killConnectionToken)
        {
            while (true)
            {
                var receiveBuffer = new byte[200_000];
                var buffer = new ArraySegment<byte>(new byte[1024 * 1]);
                var messageType = WebSocketMessageType.Text;

                try
                {
                    while (_webSocket.State == WebSocketState.Open)
                    {
                        var receiveSize = 0;

                        while (_webSocket.State == WebSocketState.Open)
                        {
                            var result = await _webSocket.ReceiveAsync(buffer, killConnectionToken);

                            messageType = result.MessageType;
                            Buffer.BlockCopy(buffer.Array, 0, receiveBuffer, receiveSize, result.Count);
                            receiveSize += result.Count;
                            if (result.EndOfMessage)
                                break;
                        }

                        if (messageType == WebSocketMessageType.Close)
                            break;

                        var messageArray = new byte[receiveSize];
                        Buffer.BlockCopy(receiveBuffer, 0, messageArray, 0, receiveSize);

                        if (receiveSize == 1 && messageArray[0] == HTB_MSG[0])
                        {
                            await _webSocket.SendAsync(HTB_MSG, WebSocketMessageType.Binary, true, CancellationToken.None);
                            continue;
                        }

                        var data = MessagePackSerializer.ConvertToJson(messageArray);
                        if (data != null) ValidateResponses.ValidateWebSocketMessageResponse(data);
                    }
                }
                catch (WebSocketException ex)
                {
                    Console.WriteLine($"Websocket Error {ex.StackTrace}");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("WebSocket disconnected, operation cancelled");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Receive WebSocket Message Error: {ex.StackTrace}");
                }

                if (killConnectionToken.IsCancellationRequested)
                    break;

                if (_webSocket.State != WebSocketState.Open)
                {
                    _webSocket.Abort();
                    await Task.Delay(1000, killConnectionToken);
                    await CreateSocket();
                }
            }
        }
    }
}

using API.AUTH.Interface;
using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace API.AUTH.Service
{
    public class WebSocketManagerService : IWebSockerManager
    {
        private readonly ConcurrentDictionary<Guid, WebSocket> _connections = new ConcurrentDictionary<Guid, WebSocket>();
        private readonly TimeSpan _checkInterval = TimeSpan.FromSeconds(10);

        public async Task AddConnectionAsync(Guid userId, WebSocket socket)
        {
            _connections.TryAdd(userId, socket);
            await StartSendingPingAsync(userId);
            Console.WriteLine($"User with ID {userId} connected via WebSocket.");
        }

        public async Task RemoveConnectionAsync(Guid userId)
        {
            _connections.TryRemove(userId, out _);
            Console.WriteLine($"User with ID {userId} disconnected from WebSocket.");
        }

        private async Task StartSendingPingAsync(Guid userId)
        {
            while (_connections.TryGetValue(userId, out WebSocket socket))
            {
                if (socket.State != WebSocketState.Open)
                {
                    Console.WriteLine($"WebSocket for user with ID {userId} is not in Open state. Stopping ping.");
                    break;
                }

                try
                {
                    // Envia uma mensagem de ping ao cliente para verificar se a conexão ainda está ativa
                    Console.WriteLine($"Ping sent to user with ID {userId}.");
                    var buffer = new byte[4];
                    var pingMessage = new ArraySegment<byte>(buffer, 0, buffer.Length);
                    await socket.SendAsync(pingMessage, WebSocketMessageType.Binary, true, CancellationToken.None);

                    await Task.Delay(_checkInterval);
                }
                catch
                {
                    break;
                }
            }
                Console.WriteLine($"StartSendingPingAsync stopped for user with ID {userId}.");

            await RemoveConnectionAsync(userId);
        }

        public async Task NotifyLoggedInUsersAsync(Guid userId, string message)
        {
            // Notifica todos os usuários logados, exceto o próprio usuário que fez o login
            Console.WriteLine($"{userId} {message}");
            if (_connections.TryGetValue(userId, out WebSocket socket) && socket.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(message));
                await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}

using API.AUTH.ContextBase;
using API.AUTH.Interface;
using Microsoft.AspNetCore.SignalR;

namespace API.AUTH
{
    public class WebSocketHub : Hub
    {
        private readonly IWebSockerManager _webSockerManager;

        public WebSocketHub(IWebSockerManager webSockerManager)
        {
            _webSockerManager = webSockerManager;
        }

        public override async Task OnConnectedAsync()
        {
            // Obter o identificador exclusivo do usuário logado (neste caso, estamos usando o ConnectionId como identificador)
            var connectionId = Context.ConnectionId;



            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Obter o identificador exclusivo do usuário logado
            var userId = Context.UserIdentifier;

            // Remover a conexão WebSocket quando o usuário desconectar
            await _webSockerManager.RemoveConnectionAsync(Guid.Parse(userId));

            await base.OnDisconnectedAsync(exception);
        }
    }
}
using System.Net.WebSockets;

namespace API.AUTH.Interface
{
    public interface IWebSockerManager
    {
        Task NotifyLoggedInUsersAsync(Guid userId, string message);
        Task AddConnectionAsync(Guid id, WebSocket webSockets);
        Task RemoveConnectionAsync(Guid userId);
    }
}

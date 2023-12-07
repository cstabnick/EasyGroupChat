
using EasyGroupChat.Clients;
using EasyGroupChat.Server;
using System.Net.WebSockets;

namespace EasyGroupChat.Managers
{
    // todo: Should this class exist?
    public class WebSocketServerManager : IServerManager
    {
        WebSocketServer _server ;
        public WebSocketServerManager()
        {
            _server = new(Guid.NewGuid());

        }

        public void Connect(Guid serverId, IClient client)
        {

            _server.AddClient(client);
        }

        public bool IsClientDisconnected(Guid clientId)
        {
            return _server.IsClientDisconnected(clientId);
        }
    }
}

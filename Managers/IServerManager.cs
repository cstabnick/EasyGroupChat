using EasyGroupChat.Clients;
using System.Net.WebSockets;

namespace EasyGroupChat.Managers
{
    public interface IServerManager
    {
        bool IsClientDisconnected(Guid clientId);
        void Connect(Guid serverId, IClient client);
    }
}

using EasyGroupChat.Clients;

namespace EasyGroupChat.Server
{
    public interface IServer
    {
        public void AddClient(IClient client);
        public bool IsClientDisconnected(Guid clientId);
    }
}

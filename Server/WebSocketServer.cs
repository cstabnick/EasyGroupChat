using EasyGroupChat.Clients;
using EasyGroupChat.Util;
using System.Net.WebSockets;

namespace EasyGroupChat.Server
{
    public class WebSocketServer : IServer
    {
        Dictionary<Guid, Channel> _channels = new();
        Dictionary<Guid, IClient> _clients = new();

        public Guid ServerID { get; set; }
        private Task _tFeedClientsGarbage;
        private async Task FeedGarbage()
        {
            while (true)
            {
                await Task.Delay(1000);
                foreach (var client in _clients)
                {
                    _ = Task.Run(async () => await client.Value.SendTextAsync($"feeding garbage, you are client {client.Key}", CancellationToken.None));
                }
            }
        }

        public WebSocketServer(Guid serverId)
        {
            ServerID = serverId;

            _tFeedClientsGarbage = Task.Run(FeedGarbage);

        }

        internal void NewChannel(Guid channelId)
        {
            _channels[channelId] = new Channel() { ID = channelId, Name = Util.Constants.S_DEFAULT_CHANNEL_NAME };
        }

        public void AddClient(IClient client)
        {
            _clients[client.ClientID] = client;
        }

        public bool IsClientDisconnected(Guid clientId)
        {
            return !_clients.ContainsKey(clientId);
        }
    }
}

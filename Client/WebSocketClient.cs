using System.Net.WebSockets;
using EasyGroupChat.Util;

namespace EasyGroupChat.Clients
{
    public class WebSocketClient : IClient
    {
        private WebSocket _ws { get; set; }
        public Guid ClientID { get; private set; }


        public WebSocketClient(WebSocket ws, Guid clientId)
        {
            _ws = ws;
            ClientID = clientId;
        }

        public async Task SendTextAsync(string text, CancellationToken cancellationToken)
        {
            await _ws.SendTextAsync(text, cancellationToken);
        }
    }
}

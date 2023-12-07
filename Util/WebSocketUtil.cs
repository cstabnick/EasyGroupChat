using System.Net.WebSockets;
using System.Text;

namespace EasyGroupChat.Util
{
    public static class WebSocketExtensions
    {
        public static async Task SendTextAsync(this WebSocket ws, string text, CancellationToken? cancellationToken = null)
        {

            if (!cancellationToken.HasValue)
            {
                cancellationToken = CancellationToken.None;
            }

            var textAsBytes = Encoding.UTF8.GetBytes(text);
            await ws.SendAsync(buffer: textAsBytes,
                messageType: WebSocketMessageType.Text,
                endOfMessage: true,
                (CancellationToken)cancellationToken);

        }

    }
}

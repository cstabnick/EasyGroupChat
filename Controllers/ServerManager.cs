using EasyGroupChat.Clients;
using EasyGroupChat.Managers;
using EasyGroupChat.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading;

namespace EasyGroupChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerManager : ControllerBase
    {
        IServerManager _serverManager;
        public ServerManager(IServerManager serverManager)
        {
            _serverManager = serverManager;
        }

        [HttpPost("create")]
        public IActionResult CreateServer()
        {
            // Should be a channel manager, maybe something Server holds a reference to?
            return Ok();
            //return Ok(_serverManager.CreateNewServer(new ServerConfig() { OwnerUserId = Guid.NewGuid(), Password = "fish123" }).ToString());
        }

        [Route("connect/{id}")]
        public async Task Connect(Guid id)
        {
            // try, catch tell them to use a potential tcplistener
            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

            await webSocket.SendTextAsync("Connecting...");

            // actually do some middeware auth to id or something idk just get a client id
            Guid clientId = Guid.NewGuid();

            WebSocketClient wsc = new WebSocketClient(webSocket, clientId);
            IClient client = (IClient)wsc;

            _serverManager.Connect(id, client);
            await Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);

                    if (_serverManager.IsClientDisconnected(wsc.ClientID))
                        break;
                }
            });

        }
    }
}

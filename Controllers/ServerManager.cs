using EasyGroupChat.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public void CreateServer()
        {
            _serverManager.CreateNewServer(new ServerConfig() { OwnerUserID = Guid.NewGuid(), Password = "fish123" });
        }

        [HttpGet("connect/{id}")]
        public void Connect(int id)
        {
            Console.WriteLine(id);

        }
    }
}

using EasyGroupChat.Controllers;
using EasyGroupChat.Managers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddSingleton<IServerManager, WebSocketServerManager>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();

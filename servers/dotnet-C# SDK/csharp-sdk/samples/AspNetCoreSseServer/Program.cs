using ModelContextProtocol;
using AspNetCoreSseServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMcpServer().WithTools();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapMcpSse();

app.Run();

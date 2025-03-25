using AspNetCoreSseServer;
using Demo.MCPServer.Database;
using Demo.MCPServer.Repositories;
using Demo.MCPServer.Tools;
using ModelContextProtocol;

// 创建并初始化数据库
const string DbPath = "students.db";
var dbContext = DemoDbContext.Create(DbPath);
await Database.InitializeDatabaseAsync(dbContext);

// 创建Repository
var repository = new DataRepository(dbContext);

// 初始化工具类
StudentScoreTool.Initialize(repository);


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMcpServer()
    .WithTools();

var app = builder.Build();
app.MapMcpSse();

await app.RunAsync();

using Demo.MCPServer.Tools;
using Demo.MCPServer.Repositories;
using Demo.MCPServer.Database;
using MCPSharp;

// 创建并初始化数据库
const string DbPath = "students.db";
var dbContext = DemoDbContext.Create(DbPath);
await Database.InitializeDatabaseAsync(dbContext);

// 创建Repository
var repository = new DataRepository(dbContext);

// 初始化工具类
StudentScoreTool.Initialize(repository);

// 启动MCP服务器
// Console.WriteLine("正在启动MCP服务器...");
await MCPServer.StartAsync("学生成绩查询服务器", "1.0.0");

# MCP协议示例项目集合

这个仓库包含了多种语言实现的MCP（Model Context Protocol）协议的服务器和客户端示例。

## 项目结构

- `servers/` - 包含各种语言实现的MCP服务器示例
  - `dotnet-MCPSharp/` - 基于.NET MCPSharp实现的MCP服务示例（学生成绩管理系统）
  - `dotnet-C# SDK` - 基于MCP官方 MCP C# SDK实现的服务示例（学生成绩管理系统）


## 关于MCP协议

MCP（Model Context Protocol）是一种模型上下文交互标准协议，为AI模型推理提供标准化的上下文信息交互方式。它允许客户端和服务器之间进行结构化的上下文信息交换，提升AI模型推理的效率和准确性。

## 示例应用

### .NET学生成绩管理系统

位于`servers/dotnet`目录，这是一个基于C#和SQLite的学生成绩管理系统，使用MCP协议提供数据查询接口。详细信息请查看该目录中的README.md文件。

## 如何使用

每个示例项目都有其自己的README文件，提供了详细的安装和使用说明。请参考相应目录中的文档。

## 贡献

欢迎贡献更多语言实现的MCP协议示例！如果您想添加新的示例，请遵循现有的项目结构，并确保提供详细的文档。

## 许可证

本项目采用MIT许可证 - 详见[LICENSE](LICENSE)文件 
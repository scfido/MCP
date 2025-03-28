# MCP-DB-Tool - 学生成绩管理系统

[![开源许可证](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

这是一个基于C#和SQLite的学生成绩管理系统，使用MCP协议提供数据查询接口，可以方便地管理和查询学生成绩信息。

## 功能特点

- 使用SQLite数据库存储学生、科目和成绩信息
- 提供丰富的成绩查询功能
  - 根据学生名称和科目查询具体分数
  - 支持按性别、班级、年级等条件查询
- 支持统计分析功能
  - 提供平均分、最高分、最低分等统计数据
  - 支持按不同维度进行数据分组
- 基于MCP协议实现远程调用接口
- 轻量级设计，易于部署和使用

## 快速开始

### 系统要求

- .NET 9.0 或更高版本
- SQLite 数据库支持

### 安装步骤

1. 克隆仓库
```bash
git clone https://github.com/yourusername/MCP-DB-Tool.git
cd MCP-DB-Tool
```

2. 构建项目
```bash
dotnet build
```

3. 运行应用
```bash
dotnet run
```

默认情况下，服务将在 `localhost:5000` 启动。

## 运行截图

以下是系统运行的示例截图：

![运行截图1](/servers/dotnet/docs/demo1.jpg)
![运行截图2](/servers/dotnet/docs/demo2.jpg)

## 使用指南

### 基本使用

程序启动后会自动初始化数据库并添加示例数据。您可以将本程序添加到Claude Desktop中运行，通过其直观的界面执行各项功能。

### 在Claude Desktop中运行

本程序通过配置文件与Claude Desktop集成，而不是通过UI界面添加应用。具体步骤如下：

1. 确保已安装Claude Desktop应用程序
2. 编辑项目根目录中的`claude_desktop_config.json`文件，配置应用参数：
   ```json
   {
     "appName": "学生成绩管理系统",
     "version": "1.0.0",
     "entryPoint": "MCP-DB-Tool.exe",
     "description": "基于MCP协议的学生成绩管理工具",
     "parameters": {
       "dbPath": "students.db"
     }
   }
   ```
3. 启动Claude Desktop，它将自动检测并加载配置文件
4. 在Claude Desktop界面中选择"学生成绩管理系统"开始使用

### 调用示例

使用MCP客户端查询学生成绩：

```csharp
// 查询张三的数学成绩
var command = new Command("QueryScore");
command.Arguments.Add("studentName", "张三");
command.Arguments.Add("subjectName", "数学");
var response = await client.ExecuteAsync(command);
var scores = JsonSerializer.Deserialize<List<ScoreInfo>>(response.Content);
```

查询成绩统计信息：

```csharp
// 查询高一年级女生的成绩统计
var command = new Command("QueryStatistics");
command.Arguments.Add("gender", "女");
command.Arguments.Add("grade", "高一");
var response = await client.ExecuteAsync(command);
var statistics = JsonSerializer.Deserialize<List<ScoreStatistics>>(response.Content);
```

## 项目结构

实际项目结构组织如下：

```
MCP-DB-Tool/
│
├── Controllers/                   # 控制器目录
│   └── StudentController.cs       # 学生成绩控制器
│
├── Models/                        # 数据模型
│   ├── Student.cs                 # 学生模型
│   ├── Subject.cs                 # 科目模型
│   └── Score.cs                   # 成绩模型
│
├── Services/                      # 业务服务
│   └── ScoreService.cs            # 成绩服务
│
├── Database/                      # 数据库相关
│   ├── DbContext.cs               # 数据库上下文
│   └── DbInitializer.cs           # 数据库初始化
│
├── Utils/                         # 工具类
│   └── MCP/                       # MCP协议实现
│       └── MCPServer.cs           # MCP服务器实现
│
├── docs/                          # 文档目录
│   ├── API.md                     # API文档
│   ├── demo1.jpg                  # 运行截图1
│   └── demo2.jpg                  # 运行截图2
│
├── claude_desktop_config.json     # Claude Desktop配置文件
├── Program.cs                     # 程序入口
├── MCP-DB-Tool.csproj             # 项目文件
├── .gitignore                     # Git忽略文件
├── LICENSE                        # 许可证文件
└── README.md                      # 项目说明文件
```

## 数据模型

- **学生(Student)**：包含学生ID、姓名、年龄、性别、班级、年级
- **科目(Subject)**：包含科目ID和名称 
- **成绩(Score)**：包含成绩ID、学生ID、科目ID和分数值

## API接口

系统通过MCP协议提供以下接口：

### 1. QueryScore - 查询学生成绩

- **描述**：根据学生名称和科目查询分数
- **参数**：
  - studentName：学生名称（必填）
  - subjectName：科目名称（可选）
- **返回**：分数信息列表，包含学生名称、科目名称和分数

### 2. QueryStatistics - 查询成绩统计信息

- **描述**：根据性别、班级、年级查询平均分、最高分、最低分
- **参数**：
  - gender：性别（可选）
  - className：班级（可选）
  - grade：年级（可选）
- **返回**：分数统计信息列表，按科目分组，包含科目名称、平均分、最高分、最低分

## 配置说明

- 数据库文件默认保存为 "students.db"
- 可以通过修改 Program.cs 中的配置来更改服务器地址和端口
- 数据库连接字符串可在 DemoDbContext.cs 中配置

## 贡献指南

我们欢迎所有形式的贡献，包括但不限于：

1. 报告问题或提出功能建议
2. 提交代码改进
3. 完善文档
4. 分享使用经验

### 贡献步骤

1. Fork 项目仓库
2. 创建特性分支 (`git checkout -b feature/amazing-feature`)
3. 提交更改 (`git commit -m 'Add some amazing feature'`)
4. 推送到分支 (`git push origin feature/amazing-feature`)
5. 创建 Pull Request

## 许可证

本项目采用MIT许可证 - 详见 [LICENSE](LICENSE) 文件 

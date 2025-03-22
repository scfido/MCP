# MCP-DB-Tool API文档

本文档详细说明了MCP-DB-Tool提供的API接口，包括参数说明、返回值格式和示例。

## MCP协议说明

MCP（Message Communication Protocol）是一种轻量级的消息通信协议，用于客户端和服务器之间的通信。在本项目中，我们使用MCP协议实现了学生成绩管理系统的远程接口。

## API概览

本系统提供以下API接口：

1. QueryScore - 查询学生成绩
2. QueryStatistics - 查询成绩统计信息

## 详细接口说明

### 1. QueryScore

**功能描述**：根据学生名称和科目查询分数信息。

**接口路径**：QueryScore

**请求参数**：

| 参数名 | 类型 | 必填 | 描述 |
| ------ | ---- | ---- | ---- |
| studentName | string | 是 | 学生姓名 |
| subjectName | string | 否 | 科目名称 |

**返回格式**：

```json
[
  {
    "studentName": "张三",
    "subjectName": "数学",
    "score": 95
  },
  {
    "studentName": "张三",
    "subjectName": "物理",
    "score": 88
  }
]
```

**响应字段说明**：

| 字段名 | 类型 | 描述 |
| ------ | ---- | ---- |
| studentName | string | 学生姓名 |
| subjectName | string | 科目名称 |
| score | number | 分数值 |

**请求示例**：

```csharp
var command = new Command("QueryScore");
command.Arguments.Add("studentName", "张三");
command.Arguments.Add("subjectName", "数学");
var response = await client.ExecuteAsync(command);
```

**响应示例**：

```json
[
  {
    "studentName": "张三",
    "subjectName": "数学",
    "score": 95
  }
]
```

### 2. QueryStatistics

**功能描述**：根据性别、班级、年级查询平均分、最高分、最低分等统计信息。

**接口路径**：QueryStatistics

**请求参数**：

| 参数名 | 类型 | 必填 | 描述 |
| ------ | ---- | ---- | ---- |
| gender | string | 否 | 性别（"男"/"女"） |
| className | string | 否 | 班级名称 |
| grade | string | 否 | 年级 |

**返回格式**：

```json
[
  {
    "subjectName": "数学",
    "averageScore": 82.5,
    "maxScore": 95,
    "minScore": 65
  },
  {
    "subjectName": "语文",
    "averageScore": 85.7,
    "maxScore": 92,
    "minScore": 72
  }
]
```

**响应字段说明**：

| 字段名 | 类型 | 描述 |
| ------ | ---- | ---- |
| subjectName | string | 科目名称 |
| averageScore | number | 平均分 |
| maxScore | number | 最高分 |
| minScore | number | 最低分 |

**请求示例**：

```csharp
var command = new Command("QueryStatistics");
command.Arguments.Add("gender", "女");
command.Arguments.Add("grade", "高一");
var response = await client.ExecuteAsync(command);
```

**响应示例**：

```json
[
  {
    "subjectName": "数学",
    "averageScore": 84.2,
    "maxScore": 96,
    "minScore": 70
  },
  {
    "subjectName": "语文",
    "averageScore": 87.5,
    "maxScore": 98,
    "minScore": 75
  }
]
```

## 错误处理

当接口调用出现错误时，会返回错误信息：

```json
{
  "error": true,
  "message": "错误信息描述"
}
```

常见错误代码及说明：

| 错误描述 | 说明 |
| -------- | ---- |
| 参数错误 | 请求参数格式不正确或缺少必要参数 |
| 未找到数据 | 根据提供的条件未找到相关数据 |
| 系统错误 | 服务器内部错误 |

## 注意事项

1. 所有接口参数均不区分大小写
2. 部分查询参数支持模糊匹配
3. 返回的数据默认按照相关度排序
4. 查询结果默认最多返回100条记录 
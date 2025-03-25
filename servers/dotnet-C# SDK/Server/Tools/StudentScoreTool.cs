using Demo.MCPServer.Repositories;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace Demo.MCPServer.Tools;

/// <summary>
/// 学生成绩查询工具
/// </summary>
[McpToolType]
public class StudentScoreTool
{
    private static DataRepository? _repository;

    public static void Initialize(DataRepository repository)
    {
        _repository = repository;
    }

    [McpTool]
    [Description("查询学生成绩")]
    public static async Task<string> QueryScoreAsync(
        [Description("学生姓名")] string studentName,
        [Description("科目名称")] string subjectName)
    {
        var scores = await _repository.QueryScoreAsync(studentName, subjectName);
        return JsonSerializer.Serialize(scores);
    }

    [McpTool]
    [Description("查询成绩统计信息")]
    public static async Task<string> QueryStatisticsAsync(
        [Description("性别")] string gender,
        [Description("班级名称")] string className,
        [Description("年级")] string grade)
    {
        var statistics = await _repository.QueryScoreStatisticsAsync(gender, className, grade);
        return JsonSerializer.Serialize(statistics);
    }
}

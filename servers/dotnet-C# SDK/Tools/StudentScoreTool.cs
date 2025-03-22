using Demo.MCPServer.Repositories;
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

    /// <summary>
    /// 查询学生成绩
    /// </summary>
    /// <param name="studentName">学生姓名</param>
    /// <param name="subjectName">科目名称</param>
    /// <returns>学生成绩列表</returns>
    [McpTool]
    public static async Task<string> QueryScoreAsync(
        [McpParameter(true)] string studentName,
        [McpParameter(false)] string subjectName)
    {
        var scores = await _repository.QueryScoreAsync(studentName, subjectName);
        return JsonSerializer.Serialize(scores);
    }

    /// <summary>
    /// 查询成绩统计信息
    /// </summary>
    /// <param name="gender">性别</param>
    /// <param name="className">班级名称</param>
    /// <param name="grade">年级</param>
    /// <returns>成绩统计信息</returns>
    [McpTool]
    public static async Task<string> QueryStatisticsAsync(
        [McpParameter(false)] string gender,
        [McpParameter(false)] string className,
        [McpParameter(false)] string grade)
    {
        var statistics = await _repository.QueryScoreStatisticsAsync(gender, className, grade);
        return JsonSerializer.Serialize(statistics);
    }
}

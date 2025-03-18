using Demo.MCPServer.Models;
using Demo.MCPServer.Repositories;
using MCPSharp;
using System.Text.Json;

namespace Demo.MCPServer.Tools
{
    // 注册工具类到MCPSharp
    [McpTool(Description = "学生成绩查询工具")]
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
        [McpTool(Description = "查询学生成绩")]
        public static async Task<string> QueryScoreAsync(
            [McpParameter(true, Description = "学生姓名")] string studentName,
            [McpParameter(false, Description = "科目名称")] string subjectName)
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
        [McpTool(Description = "查询成绩统计信息")]
        public static async Task<string> QueryStatisticsAsync(
            [McpParameter(false, Description = "性别")] string gender,
            [McpParameter(false, Description = "班级名称")] string className,
            [McpParameter(false, Description = "年级")] string grade)
        {
            var statistics = await _repository.QueryScoreStatisticsAsync(gender, className, grade);
            return JsonSerializer.Serialize(statistics);
        }
    }
}

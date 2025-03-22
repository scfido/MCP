using Demo.MCPServer.Database;
using Demo.MCPServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.MCPServer.Repositories
{
    /// <summary>
    /// 数据仓库，提供学生成绩管理相关操作
    /// </summary>
    public class DataRepository
    {
        private readonly DemoDbContext _context;

        public DataRepository(DemoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据学生名称和科目查询分数
        /// </summary>
        /// <param name="studentName">学生名称</param>
        /// <param name="subjectName">科目名称</param>
        /// <returns>分数信息</returns>
        public async Task<List<ScoreInfo>> QueryScoreAsync(string studentName, string subjectName)
        {
            var query = _context.Scores
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .AsQueryable();

            if (!string.IsNullOrEmpty(studentName))
            {
                query = query.Where(s => s.Student.Name.Contains(studentName));
            }

            if (!string.IsNullOrEmpty(subjectName))
            {
                query = query.Where(s => s.Subject.Name.Contains(subjectName));
            }

            var scores = await query.ToListAsync();

            return scores.Select(s => new ScoreInfo
            {
                StudentName = s.Student.Name,
                SubjectName = s.Subject.Name,
                Score = s.ScoreValue
            }).ToList();
        }

        /// <summary>
        /// 根据性别、班级、年级查询平均分、最高分、最低分
        /// </summary>
        /// <param name="gender">性别</param>
        /// <param name="className">班级</param>
        /// <param name="grade">年级</param>
        /// <returns>分数统计信息</returns>
        public async Task<List<ScoreStatistics>> QueryScoreStatisticsAsync(string? gender = null, string? className = null, string? grade = null)
        {
            var query = _context.Scores
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .AsQueryable();

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(s => s.Student.Gender == gender);
            }

            if (!string.IsNullOrEmpty(className))
            {
                query = query.Where(s => s.Student.Class == className);
            }

            if (!string.IsNullOrEmpty(grade))
            {
                query = query.Where(s => s.Student.Grade == grade);
            }

            // 按科目分组统计
            var result = await query
                .GroupBy(s => s.Subject.Name)
                .Select(g => new ScoreStatistics
                {
                    SubjectName = g.Key,
                    AverageScore = g.Average(s => s.ScoreValue),
                    MaxScore = g.Max(s => s.ScoreValue),
                    MinScore = g.Min(s => s.ScoreValue)
                })
                .ToListAsync();

            return result;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Demo.MCPServer.Models;

namespace Demo.MCPServer.Database;

public static class Database
{
    // 初始化数据库方法
    public static async Task InitializeDatabaseAsync(DemoDbContext context)
    {
        // 确保数据库已创建
        await context.Database.EnsureCreatedAsync();

        // 如果没有数据，添加一些示例数据
        if (!await context.Students.AnyAsync())
        {
            // 添加学生
            var students = new List<Student>
            {
                new() { Name = "张三", Age = 18, Gender = "男", Class = "1班", Grade = "高一" },
                new() { Name = "李四", Age = 17, Gender = "女", Class = "1班", Grade = "高一" },
                new() { Name = "王五", Age = 18, Gender = "男", Class = "2班", Grade = "高一" },
                new() { Name = "赵六", Age = 16, Gender = "女", Class = "2班", Grade = "高一" },
                new() { Name = "钱七", Age = 19, Gender = "男", Class = "1班", Grade = "高二" }
            };
            context.Students.AddRange(students);
            await context.SaveChangesAsync();
        }

        if (!await context.Subjects.AnyAsync())
        {
            // 添加科目
            var subjects = new List<Subject>
            {
                new() { Name = "数学" },
                new() { Name = "语文" },
                new() { Name = "英语" },
                new() { Name = "物理" },
                new() { Name = "化学" }
            };
            context.Subjects.AddRange(subjects);
            await context.SaveChangesAsync();
        }

        if (!await context.Scores.AnyAsync())
        {
            // 获取学生和科目
            var students = await context.Students.ToListAsync();
            var subjects = await context.Subjects.ToListAsync();

            // 生成随机成绩
            var random = new Random();
            var scores = new List<Score>();

            foreach (var student in students)
            {
                foreach (var subject in subjects)
                {
                    scores.Add(new Score
                    {
                        StudentId = student.Id,
                        SubjectId = subject.Id,
                        ScoreValue = random.Next(60, 101) // 60-100的随机分数
                    });
                }
            }

            context.Scores.AddRange(scores);
            await context.SaveChangesAsync();
        }

        //Console.WriteLine("数据库初始化完成");
    }
} 
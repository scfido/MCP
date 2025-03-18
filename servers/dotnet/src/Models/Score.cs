namespace Demo.MCPServer.Models
{
    /// <summary>
    /// 成绩
    /// </summary>
    public class Score
    {
        /// <summary>
        /// 成绩记录唯一标识符
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学生ID，关联到Student表
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// 科目ID，关联到Subject表
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// 分数值
        /// </summary>
        public double ScoreValue { get; set; }
        
        /// <summary>
        /// 学生对象，导航属性
        /// </summary>
        public Student Student { get; set; }
        
        /// <summary>
        /// 科目对象，导航属性
        /// </summary>
        public Subject Subject { get; set; }
    }

    
    /// <summary>
    /// 分数查询结果
    /// </summary>
    public class ScoreInfo
    {
        /// <summary>
        /// 学生名称
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 科目名称
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public double Score { get; set; }
    }

    /// <summary>
    /// 分数统计结果
    /// </summary>
    public class ScoreStatistics
    {
        /// <summary>
        /// 科目名称
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// 平均分
        /// </summary>
        public double AverageScore { get; set; }

        /// <summary>
        /// 最高分
        /// </summary>
        public double MaxScore { get; set; }

        /// <summary>
        /// 最低分
        /// </summary>
        public double MinScore { get; set; }
    }
} 
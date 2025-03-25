namespace Demo.MCPServer.Models
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 学生唯一标识符
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 学生性别
        /// </summary>
        public string Gender { get; set; }
        
        /// <summary>
        /// 学生所在班级
        /// </summary>
        public string Class { get; set; }
        
        /// <summary>
        /// 学生所在年级
        /// </summary>
        public string Grade { get; set; }
    }
} 
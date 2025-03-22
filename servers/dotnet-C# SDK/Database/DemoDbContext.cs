using Microsoft.EntityFrameworkCore;
using Demo.MCPServer.Models;

namespace Demo.MCPServer.Database
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {   
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(e => e.Id);
            
            modelBuilder.Entity<Subject>().HasKey(e => e.Id);
            
            modelBuilder.Entity<Score>().HasKey(e => e.Id);
            
            // 配置一对多关系
            modelBuilder.Entity<Score>()
                .HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId);
                
            modelBuilder.Entity<Score>()
                .HasOne(s => s.Subject)
                .WithMany()
                .HasForeignKey(s => s.SubjectId);
        }
        
        // 用于工具或手动创建上下文
        public static DemoDbContext Create(string dbPath)
        {
            var options = new DbContextOptionsBuilder<DemoDbContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;
                
            return new DemoDbContext(options);
        }
    }
} 
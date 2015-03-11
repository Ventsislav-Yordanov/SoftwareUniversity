namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Entities;
    using StudentSystem.Data.Migrations;

    public class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .Property(s => s.Name)
                .IsUnicode();

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Name)
                .IsUnicode();

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Description)
                .IsUnicode();

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Name)
                .IsUnicode();

            modelBuilder
               .Entity<Homework>()
               .Property(h => h.Content)
               .IsUnicode();
        }
    }
}

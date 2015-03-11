namespace StudentSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using StudentSystem.Entities;

    public interface IStudentSystemDbContext
    {
        IDbSet<Student> Students { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Resource> Resources { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}

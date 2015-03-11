using StudentSystem.Data.Repositories;
using StudentSystem.Entities;
namespace StudentSystem.Data
{
    public interface IStudentSystemData
    {
        IGenericRepository<Student> Students { get; }

        IGenericRepository<Homework> Homeworks { get; }

        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Resource> Resources { get; }

        int SaveChanges();
    }
}

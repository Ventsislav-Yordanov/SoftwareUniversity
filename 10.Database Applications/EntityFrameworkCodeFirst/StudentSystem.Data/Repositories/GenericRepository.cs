using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
namespace StudentSystem.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IStudentSystemDbContext context;
        private IDbSet<T> set;

        public GenericRepository(IStudentSystemDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public IQueryable<T> All(Expression<Func<T, bool>> conditions)
        {
            return this.set.Where(conditions);
        }

        public T Add(T entity)
        {
            this.Attach(entity, EntityState.Added);
            return entity;
        }

        public T Update(T entity)
        {
            this.Attach(entity, EntityState.Modified);
            return entity;
        }

        public T Delete(T entity)
        {
            this.Attach(entity, EntityState.Deleted);
            return entity;
        }

        public void Detach(T entity)
        {
            this.Attach(entity, EntityState.Detached);
        }

        public DbEntityEntry Attach(T entity, EntityState newEntityState)
        {
            var entry = this.context.Entry(entity);
            this.set.Attach(entity);
            entry.State = newEntityState;
            return entry;
        }
    }
}

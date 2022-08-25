using FaktureAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FaktureAPI.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected ApplicationContext applicationContext { get; set; }

        public RepositoryBase(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public  IQueryable<T> FindAll()
        {
            return this.applicationContext.Set<T>().AsNoTracking();
        }
        public  IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.applicationContext.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.applicationContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.applicationContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.applicationContext.Set<T>().Remove(entity);
        }
    }
}

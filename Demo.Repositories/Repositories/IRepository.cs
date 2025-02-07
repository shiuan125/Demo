using System.Linq.Expressions;

namespace Demo.Repositories.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> GetAll();
    }
}

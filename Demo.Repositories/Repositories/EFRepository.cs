using Demo.Repositories.DBModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Demo.Repositories.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DemoContext _dbContext;
        public EFRepository(DemoContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbContext.Set<TEntity>().Where(where).FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }
    }
}

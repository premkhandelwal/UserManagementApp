using Crm.Tenant.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Crm.Tenant.Data.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly ClientApplicationDbContext _dbContext;

        public BaseRepository(ClientApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

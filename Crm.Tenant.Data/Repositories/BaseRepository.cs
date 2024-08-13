using Crm.Tenant.Data.DbContexts;
using Crm.Tenant.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Crm.Tenant.Data.Repositories
{
    public class BaseRepository<T> where T : BaseModelClass
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

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext. SaveChangesAsync();
            return entity;

        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<T>> ReadAsync()
        {
            List<T> entityList = await _dbContext.Set<T>().Where(t => t.IsDeleted == false).ToListAsync();
            return entityList;
        }
    }
}

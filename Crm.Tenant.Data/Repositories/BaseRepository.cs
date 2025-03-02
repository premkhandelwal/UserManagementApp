using Crm.Tenant.Data.DbContexts;
using Crm.Tenant.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
namespace Crm.Tenant.Data.Repositories
{
    public class BaseRepository<T> where T : BaseModelClass
    {
        protected readonly ClientApplicationDbContext _dbContext;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(ClientApplicationDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> res = await _dbContext.Set<T>().AddAsync(entity);
            return res.Entity;
        }

        public virtual T UpdateAsync(T entity)
        {
            var local = _dbContext.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual T DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual async Task<T> HardDeleteAsync(T entity)
        {
            var existingEntity = await _dbContext.Set<T>().FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Set<T>().Remove(existingEntity);
            }
            else
            {
                _dbContext.Set<T>().Attach(entity);
                _dbContext.Set<T>().Remove(entity);
            }

            return entity;
        }

        public virtual async Task<List<T>> ReadAsync()
        {
            List<T> entityList = await _dbContext.Set<T>().Where(t => t.IsDeleted == false).ToListAsync();
            return entityList;
        }

        public virtual T? GetById(int id)
        {
            T? entity = _dbContext.Set<T>().FirstOrDefault(e => e.Id == id && e.IsDeleted == false);
            return entity;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate);
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<T> ReloadAsync(T entity)
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _dbContext.Attach(entity);
            }

            await entry.ReloadAsync();
            return entity;
        }
    }
}
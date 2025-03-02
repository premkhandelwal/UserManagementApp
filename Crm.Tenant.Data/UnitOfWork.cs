using Crm.Tenant.Data.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Crm.Tenant.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClientApplicationDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ClientApplicationDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}

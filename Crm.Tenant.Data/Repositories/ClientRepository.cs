using Crm.Tenant.Data.DbContexts;
using Crm.Tenant.Data.Models.Masters;

namespace Crm.Tenant.Data.Repositories
{
    public class ClientRepository: BaseRepository<ClientModel>
    {
        public ClientRepository(ClientApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

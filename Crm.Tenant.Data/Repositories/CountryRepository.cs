using Crm.Tenant.Data.DbContexts;
using CRM.Data.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Tenant.Data.Repositories
{
    public class CountryRepository : BaseRepository<CountryModel>
    {
        public CountryRepository(ClientApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

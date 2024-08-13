using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Crm.Admin.Data.Models;

namespace Crm.Admin.Data
{
    public class AdminDbContext : IdentityDbContext<CrmIdentityUser>
    {
        public DbSet<RefreshToken>? RefreshTokens { get; set; }

        public AdminDbContext(DbContextOptions<AdminDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}

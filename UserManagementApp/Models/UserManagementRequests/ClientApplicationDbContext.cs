using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagementApp.Models.Masters;
using UserManagementData;

namespace UserManagementApp.Models.UserManagementRequests
{
    public class ClientApplicationDbContext : DbContext
    {
        public DbSet<MemberModel>? Members { get; set; }
        public DbSet<ClientModel>? Clients { get; set; }
        public ClientApplicationDbContext(DbContextOptions<ClientApplicationDbContext> options) : base(options)
        {
        }
    }
}

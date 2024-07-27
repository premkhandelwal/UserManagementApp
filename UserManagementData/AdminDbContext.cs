using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementApp.Models;

namespace UserManagementData
{
    public class AdminDbContext : IdentityDbContext<ApplicationUser>
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

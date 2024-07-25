using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagementApp.Models.Masters;
using UserManagementData;

namespace UserManagementApp.Models.UserManagementRequests
{
    public class ClientApplicationDbContext : DbContext
    {
        public DbSet<ClientModel>? Clients { get; set; }
        public DbSet<CountryModel>? Countries { get; set; }
        public DbSet<CurrencyModel>? Currencies { get; set; }
        public DbSet<DeliveredToModel>? DeliveredTo { get; set; }
        public DbSet<DeliveryTimeModel>? DeliveryTime { get; set; }
        public DbSet<MaterialModel>? Materials { get; set; }
        public DbSet<MemberModel>? Members { get; set; }
        public DbSet<MtcTypeModel>? MtcTypes { get; set; }
        public DbSet<PaymentTypeModel>? PaymentTypes { get; set; }
        public DbSet<ProductModel>? Products { get; set; }
        public DbSet<QuotationCloseReasonModel>? QuotationCloseReasons { get; set; }
        public DbSet<TransportModeModel>? TransportModes { get; set; }
        public DbSet<ValidityModel>? Validities { get; set; }
        public ClientApplicationDbContext(DbContextOptions<ClientApplicationDbContext> options) : base(options)
        {
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRM.Api.Models.Masters;
using CRM.Admin.Data;
using CRM.Api.Models.Quotation;

namespace CRM.Api.Models.UserManagementRequests
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

        public DbSet<QuotationModel>? Quotations { get; set; }
        public DbSet<QuotationItemModel>? QuotationItems { get; set; }
        public DbSet<QuotationTermsModel>? QuotationTerms { get; set; }
        public ClientApplicationDbContext(DbContextOptions<ClientApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys for all models
            var entitiesWithPrimaryKey = new[]
            {
                typeof(DeliveredToModel),
                typeof(CountryModel),
                typeof(ClientModel),
                typeof(CurrencyModel),
                typeof(DeliveryTimeModel),
                typeof(MaterialModel),
                typeof(MemberModel),
                typeof(MtcTypeModel),
                typeof(PaymentTypeModel),
                typeof(ProductModel),
                typeof(QuotationCloseReasonModel),
                typeof(TransportModeModel),
                typeof(ValidityModel),
                typeof(QuotationModel),
                typeof(QuotationItemModel),
                typeof(QuotationTermsModel)
            };

            foreach (var entity in entitiesWithPrimaryKey)
            {
                modelBuilder.Entity(entity).Property("Id").ValueGeneratedOnAdd();
                modelBuilder.Entity(entity).HasKey("Id");
            }

            

            // Configure relationships
            modelBuilder.Entity<DeliveredToModel>()
                .HasOne(dt => dt.TransportMode)
                .WithMany()
                .HasForeignKey(dt => dt.TransportModeId);

            modelBuilder.Entity<MemberModel>()
                .HasOne(m => m.Client)
                .WithMany()
                .HasForeignKey(m => m.ClientId);

            modelBuilder.Entity<QuotationModel>()
                .HasMany(q => q.QuotationItems)
                .WithOne(qi => qi.Quotation)
                .HasForeignKey(qi => qi.QuotationId);

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(qt => qt.Quotation)
                .WithOne()
                .HasForeignKey<QuotationTermsModel>(qt => qt.QuotationId);


        }

    }
}

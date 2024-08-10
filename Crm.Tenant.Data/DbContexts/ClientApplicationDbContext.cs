using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRM.Api.Models.Quotation;
using CRM.Data.Models.Masters;
using Crm.Tenant.Data.Models.Masters;

namespace Crm.Tenant.Data.DbContexts
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

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(m => m.CountryofOriginModel)
                .WithMany()
                .HasForeignKey(m => m.CountryofOriginId);

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(m => m.CurrencyModel)
                .WithMany()
                .HasForeignKey(m => m.CurrencyId);

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(m => m.DeliveredToModel)
                .WithMany()
                .HasForeignKey(m => m.DelieveryNameId);

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(m => m.DeliveryTimeModel)
                .WithMany()
                .HasForeignKey(m => m.DeliveryTimeId);

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(m => m.MtcTypeModel)
                .WithMany()
                .HasForeignKey(m => m.MtcTypeId);

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(m => m.PaymentTypeModel)
                .WithMany()
                .HasForeignKey(m => m.PaymentId);

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(m => m.PackingTypeModel)
                .WithMany()
                .HasForeignKey(m => m.PackingTypeId);

            modelBuilder.Entity<QuotationTermsModel>()
                .HasOne(m => m.ValidityModel)
                .WithMany()
                .HasForeignKey(m => m.ValidityId);
        }

    }
}

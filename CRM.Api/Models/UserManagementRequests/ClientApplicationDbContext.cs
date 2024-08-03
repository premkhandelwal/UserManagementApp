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
            // Configure the primary key for TransportModeModel
            modelBuilder.Entity<TransportModeModel>()
                .HasKey(tm => tm.Id);

            // Configure the primary key for DeliveredToModel
            modelBuilder.Entity<DeliveredToModel>()
                .HasKey(dt => dt.Id);

            // Configure the one-to-many relationship between TransportModeModel and DeliveredToModel
            modelBuilder.Entity<DeliveredToModel>()
                .HasOne(dt => dt.TransportMode)
                .WithMany()
                .HasForeignKey(dt => dt.TransportModeId);

            // Configure the primary key for TransportModeModel
            modelBuilder.Entity<ClientModel>()
                .HasKey(tm => tm.Id);

            // Configure the primary key for DeliveredToModel
            modelBuilder.Entity<MemberModel>()
                .HasKey(dt => dt.Id);

            // Configure the one-to-many relationship between TransportModeModel and DeliveredToModel
            modelBuilder.Entity<MemberModel>()
                .HasOne(dt => dt.Client)
                .WithMany()
                .HasForeignKey(dt => dt.ClientId);
            modelBuilder.Entity<QuotationModel>()
               .HasKey(q => q.Id);

            modelBuilder.Entity<QuotationModel>()
                .Property(q => q.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<QuotationItemModel>()
                .HasKey(qi => qi.Id);

            modelBuilder.Entity<QuotationItemModel>()
                .Property(qi => qi.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<QuotationTermsModel>()
                .HasKey(qt => qt.Id);

            modelBuilder.Entity<QuotationTermsModel>()
                .Property(qt => qt.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<QuotationModel>()
                .HasMany(q => q.QuotationItems)
                .WithOne(qi => qi.Quotation)
                .HasForeignKey(qi => qi.QuotationId);

        }
    }
}

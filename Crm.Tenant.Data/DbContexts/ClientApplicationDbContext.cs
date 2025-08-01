﻿using Microsoft.EntityFrameworkCore;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Admin.Service.Models;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using Crm.Tenant.Data.Models.PurchaseOrder;
using Crm.Tenant.Data.Models.Masters.WorkOrder;
using System.Reflection.Emit;
using Crm.Tenant.Data.Models.WorkOrder;

namespace Crm.Tenant.Data.DbContexts
{
    public class ClientApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; } 
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
        public DbSet<QuotationFieldsModel>? Quotations { get; set; }
        public DbSet<QuotationItemModel>? QuotationItems { get; set; }
        public DbSet<QuotationTermsModel>? QuotationTerms { get; set; }
        public DbSet<PurchaseOrderFieldsModel>? PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItemModel>? PurchaseOrderItems { get; set; }
        public DbSet<PurchaseOrderTermsModel>? PurchaseOrderTerms { get; set; }
        public DbSet<QuotationFollowUpModel>? QuotationFollowUp { get; set; }
        public DbSet<UnitModel>? Units { get; set; }
        public DbSet<HsnModel> Hsn { get; set; }
        public DbSet<VendorModel>? Vendor { get; set; }
        public DbSet<VendorMemberModel> VendorMember { get; set; }
        public DbSet<PartNumberModel> PartNumbers { get; set; }
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
                typeof(QuotationFieldsModel),
                typeof(QuotationItemModel),
                typeof(QuotationTermsModel),
                typeof(QuotationFollowUpModel),
                typeof(PurchaseOrderFieldsModel),
                typeof(PurchaseOrderItemModel),
                typeof(PurchaseOrderTermsModel),
                typeof(UnitModel),
                typeof(HsnModel),
                typeof(VendorModel),
                typeof(VendorMemberModel),
                typeof(UserModel),
                typeof(PartNumberModel),
                typeof(WorkOrderFieldsModel),
                typeof(WorkOrderItemModel),
                typeof(WorkOrderStatusModel)
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

            modelBuilder.Entity<VendorMemberModel>()
                .HasOne(m => m.Vendor)
                .WithMany()
                .HasForeignKey(m => m.VendorId);

            QuotationKeys(modelBuilder);
            PurchaseOrderKeys(modelBuilder);
            WorkOrderKeys(modelBuilder);
        }

        private void QuotationKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuotationFieldsModel>()
                .HasOne(modelBuilder => modelBuilder.QuotationMadeByUserModel)
                .WithMany()
                .HasForeignKey(m => m.QuotationMadeById);

            modelBuilder.Entity<QuotationFieldsModel>()
               .HasOne(modelBuilder => modelBuilder.QuotationAssignedToUserModel)
               .WithMany()
               .HasForeignKey(m => m.QuotationAssignedToId);

            modelBuilder.Entity<QuotationFieldsModel>()
               .HasOne(modelBuilder => modelBuilder.QuotationCompanyModel)
               .WithMany()
               .HasForeignKey(m => m.QuotationCompanyId);

            modelBuilder.Entity<QuotationFieldsModel>()
               .HasOne(modelBuilder => modelBuilder.QuotationAttentionModel)
               .WithMany()
               .HasForeignKey(m => m.QuotationAttentionId);

            modelBuilder.Entity<QuotationFieldsModel>()
                .HasOne(modelBuilder => modelBuilder.QuotationCloseReasonsModel)
                .WithMany()
                .HasForeignKey(m => m.QuotationCloseReasonId);

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
                .HasForeignKey(m => m.DeliveryNameId);

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

        private void PurchaseOrderKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseOrderFieldsModel>()
                .HasOne(modelBuilder => modelBuilder.PurchaseOrderMadeByUserModel)
                .WithMany()
                .HasForeignKey(m => m.PurchaseOrderMadeById);

            modelBuilder.Entity<PurchaseOrderFieldsModel>()
               .HasOne(modelBuilder => modelBuilder.PurchaseOrderAssignedToUserModel)
               .WithMany()
               .HasForeignKey(m => m.PurchaseOrderAssignedToId);

            modelBuilder.Entity<PurchaseOrderFieldsModel>()
               .HasOne(modelBuilder => modelBuilder.PurchaseOrderVendorModel)
               .WithMany()
               .HasForeignKey(m => m.PurchaseOrderVendorId);

            modelBuilder.Entity<PurchaseOrderFieldsModel>()
               .HasOne(modelBuilder => modelBuilder.PurchaseOrderVendorMemberModel)
               .WithMany()
               .HasForeignKey(m => m.PurchaseOrderAttentionId);

            modelBuilder.Entity<PurchaseOrderTermsModel>()
                .HasOne(m => m.CountryofOriginModel)
                .WithMany()
                .HasForeignKey(m => m.CountryofOriginId);

            modelBuilder.Entity<PurchaseOrderTermsModel>()
                .HasOne(m => m.CurrencyModel)
                .WithMany()
                .HasForeignKey(m => m.CurrencyId);

            modelBuilder.Entity<PurchaseOrderTermsModel>()
                .HasOne(m => m.DeliveredToModel)
                .WithMany()
                .HasForeignKey(m => m.DeliveryNameId);

            modelBuilder.Entity<PurchaseOrderTermsModel>()
                .HasOne(m => m.MtcTypeModel)
                .WithMany()
                .HasForeignKey(m => m.MtcTypeId);

            modelBuilder.Entity<PurchaseOrderTermsModel>()
                .HasOne(m => m.PaymentTypeModel)
                .WithMany()
                .HasForeignKey(m => m.PaymentId);

            modelBuilder.Entity<PurchaseOrderTermsModel>()
                .HasOne(m => m.PackingTypeModel)
                .WithMany()
                .HasForeignKey(m => m.PackingTypeId);

            modelBuilder.Entity<PurchaseOrderTermsModel>()
                .HasOne(m => m.ValidityModel)
                .WithMany()
                .HasForeignKey(m => m.ValidityId);
        }

        private void WorkOrderKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOrderFieldsModel>()
              .HasOne(modelBuilder => modelBuilder.WorkOrderCompany)
              .WithMany()
              .HasForeignKey(m => m.WorkOrderCompanyId);

            modelBuilder.Entity<WorkOrderFieldsModel>()
                 .HasIndex(e => e.WorkOrderId)
                 .IsUnique()
                 .HasDatabaseName("IX_WorkOrderFields_WorkOrderId_Unique");

            modelBuilder.Entity<WorkOrderItemModel>()
                .HasOne(modelBuilder => modelBuilder.WorkOrderFieldsModel)
                .WithMany()
                .HasForeignKey(m => m.WorkOrderId);

            modelBuilder.Entity<WorkOrderItemModel>()
                .HasOne(modelBuilder => modelBuilder.PartNumberModel)
                .WithMany()
                .HasForeignKey(m => m.PartNumberId);

            modelBuilder.Entity<WorkOrderStatusModel>(entity =>
            { 
                entity.HasOne(modelBuilder => modelBuilder.WorkOrderModel)
                .WithOne();
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            }
            );
        }

    }
}

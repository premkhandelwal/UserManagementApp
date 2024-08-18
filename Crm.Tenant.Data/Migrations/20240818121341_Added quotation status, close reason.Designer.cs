﻿// <auto-generated />
using System;
using Crm.Tenant.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    [DbContext(typeof(ClientApplicationDbContext))]
    [Migration("20240818121341_Added quotation status, close reason")]
    partial class Addedquotationstatusclosereason
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Crm.Api.Models.Quotation.QuotationFieldsModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("DiscountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GrandTotal")
                        .HasColumnType("float");

                    b.Property<double>("GstAmount")
                        .HasColumnType("float");

                    b.Property<double>("GstPercent")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("NetTotal")
                        .HasColumnType("float");

                    b.Property<double>("OtherCharges")
                        .HasColumnType("float");

                    b.Property<string>("QuotationAssignedToId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuotationAttentionId")
                        .HasColumnType("int");

                    b.Property<int?>("QuotationCloseReasonId")
                        .HasColumnType("int");

                    b.Property<int?>("QuotationCompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("QuotationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuotationImportance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuotationMadeById")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuotationPriority")
                        .HasColumnType("int");

                    b.Property<string>("QuotationStage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuotationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuotationCloseReasonId");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("Crm.Api.Models.Quotation.QuotationItemModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Margin")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("PackagingCharges")
                        .HasColumnType("float");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("QuotationId")
                        .HasColumnType("int");

                    b.Property<int>("SrNo")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("QuotationId");

                    b.ToTable("QuotationItems");
                });

            modelBuilder.Entity("Crm.Api.Models.Quotation.QuotationTermsModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CountryofOriginId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryNameId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryTimeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MtcTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("PackingTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("QuotationId")
                        .HasColumnType("int");

                    b.Property<int?>("ValidityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryofOriginId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DeliveryNameId");

                    b.HasIndex("DeliveryTimeId");

                    b.HasIndex("MtcTypeId");

                    b.HasIndex("PackingTypeId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("QuotationId");

                    b.HasIndex("ValidityId");

                    b.ToTable("QuotationTerms");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.ClientModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.CountryModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.CurrencyModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.DeliveredToModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TransportModeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportModeId");

                    b.ToTable("DeliveredTo");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.DeliveryTimeModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTime");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.MaterialModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MaterialName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.MemberModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsWhatsApp")
                        .HasColumnType("bit");

                    b.Property<string>("MemberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("SkypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.MtcTypeModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("MtcType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MtcTypes");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.PaymentTypeModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.ProductModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.QuotationCloseReasonModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("QuotationCloseReason")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuotationCloseReasons");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.TransportModeModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransportMode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransportModes");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.ValidityModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Validity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Validities");
                });

            modelBuilder.Entity("Crm.Api.Models.Quotation.QuotationFieldsModel", b =>
                {
                    b.HasOne("Crm.Tenant.Data.Models.Masters.QuotationCloseReasonModel", "QuotationCloseReason")
                        .WithMany()
                        .HasForeignKey("QuotationCloseReasonId");

                    b.Navigation("QuotationCloseReason");
                });

            modelBuilder.Entity("Crm.Api.Models.Quotation.QuotationItemModel", b =>
                {
                    b.HasOne("Crm.Api.Models.Quotation.QuotationFieldsModel", "QuotationFieldsModel")
                        .WithMany()
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuotationFieldsModel");
                });

            modelBuilder.Entity("Crm.Api.Models.Quotation.QuotationTermsModel", b =>
                {
                    b.HasOne("Crm.Tenant.Data.Models.Masters.CountryModel", "CountryofOriginModel")
                        .WithMany()
                        .HasForeignKey("CountryofOriginId");

                    b.HasOne("Crm.Tenant.Data.Models.Masters.CurrencyModel", "CurrencyModel")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("Crm.Tenant.Data.Models.Masters.DeliveredToModel", "DeliveredToModel")
                        .WithMany()
                        .HasForeignKey("DeliveryNameId");

                    b.HasOne("Crm.Tenant.Data.Models.Masters.DeliveryTimeModel", "DeliveryTimeModel")
                        .WithMany()
                        .HasForeignKey("DeliveryTimeId");

                    b.HasOne("Crm.Tenant.Data.Models.Masters.MtcTypeModel", "MtcTypeModel")
                        .WithMany()
                        .HasForeignKey("MtcTypeId");

                    b.HasOne("Crm.Tenant.Data.Models.Masters.TransportModeModel", "PackingTypeModel")
                        .WithMany()
                        .HasForeignKey("PackingTypeId");

                    b.HasOne("Crm.Tenant.Data.Models.Masters.PaymentTypeModel", "PaymentTypeModel")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("Crm.Api.Models.Quotation.QuotationFieldsModel", "QuotationFieldsModel")
                        .WithMany()
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crm.Tenant.Data.Models.Masters.ValidityModel", "ValidityModel")
                        .WithMany()
                        .HasForeignKey("ValidityId");

                    b.Navigation("CountryofOriginModel");

                    b.Navigation("CurrencyModel");

                    b.Navigation("DeliveredToModel");

                    b.Navigation("DeliveryTimeModel");

                    b.Navigation("MtcTypeModel");

                    b.Navigation("PackingTypeModel");

                    b.Navigation("PaymentTypeModel");

                    b.Navigation("QuotationFieldsModel");

                    b.Navigation("ValidityModel");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.DeliveredToModel", b =>
                {
                    b.HasOne("Crm.Tenant.Data.Models.Masters.TransportModeModel", "TransportMode")
                        .WithMany()
                        .HasForeignKey("TransportModeId");

                    b.Navigation("TransportMode");
                });

            modelBuilder.Entity("Crm.Tenant.Data.Models.Masters.MemberModel", b =>
                {
                    b.HasOne("Crm.Tenant.Data.Models.Masters.ClientModel", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}

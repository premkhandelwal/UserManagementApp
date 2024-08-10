﻿// <auto-generated />
using System;
using Crm.Tenant.Data.DbContexts;
using CRM.Api.Models.UserManagementRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRM.Api.Migrations
{
    [DbContext(typeof(ClientApplicationDbContext))]
    partial class ClientApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CRM.Admin.Service.Models.IUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("IUser");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.ClientModel", b =>
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

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.CountryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.CurrencyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.DeliveredToModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("TransportModeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportModeId");

                    b.ToTable("DeliveredTo");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.DeliveryTimeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTime");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.MaterialModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MaterialName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.MemberModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientId")
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

                    b.Property<string>("SkypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.MtcTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MtcType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MtcTypes");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.PaymentTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.QuotationCloseReasonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("QuotationCloseReason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuotationCloseReasons");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.TransportModeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TransportMode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransportModes");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.ValidityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Validity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Validities");
                });

            modelBuilder.Entity("CRM.Api.Models.Quotation.QuotationItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Margin")
                        .HasColumnType("float");

                    b.Property<double>("PackagingCharges")
                        .HasColumnType("float");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("QuotationId")
                        .HasColumnType("int");

                    b.Property<int?>("QuotationModelId")
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

                    b.HasIndex("QuotationModelId");

                    b.ToTable("QuotationItems");
                });

            modelBuilder.Entity("CRM.Api.Models.Quotation.QuotationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<double>("NetTotal")
                        .HasColumnType("float");

                    b.Property<double>("OtherCharges")
                        .HasColumnType("float");

                    b.Property<string>("QuotationAssignedToId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuotationAttentionId")
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

                    b.Property<int?>("QuotationTermsId")
                        .HasColumnType("int");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuotationTermsId");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("CRM.Api.Models.Quotation.QuotationTermsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CountryofOriginId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("DelieveryNameId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryTimeId")
                        .HasColumnType("int");

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

                    b.HasIndex("DelieveryNameId");

                    b.HasIndex("DeliveryTimeId");

                    b.HasIndex("MtcTypeId");

                    b.HasIndex("PackingTypeId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ValidityId");

                    b.ToTable("QuotationTerms");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.DeliveredToModel", b =>
                {
                    b.HasOne("CRM.Api.Models.Masters.TransportModeModel", "TransportMode")
                        .WithMany()
                        .HasForeignKey("TransportModeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransportMode");
                });

            modelBuilder.Entity("CRM.Api.Models.Masters.MemberModel", b =>
                {
                    b.HasOne("CRM.Api.Models.Masters.ClientModel", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CRM.Api.Models.Quotation.QuotationItemModel", b =>
                {
                    b.HasOne("CRM.Api.Models.Quotation.QuotationModel", null)
                        .WithMany("QuotationItems")
                        .HasForeignKey("QuotationModelId");
                });

            modelBuilder.Entity("CRM.Api.Models.Quotation.QuotationModel", b =>
                {
                    b.HasOne("CRM.Api.Models.Quotation.QuotationTermsModel", "QuotationTerms")
                        .WithMany()
                        .HasForeignKey("QuotationTermsId");

                    b.Navigation("QuotationTerms");
                });

            modelBuilder.Entity("CRM.Api.Models.Quotation.QuotationTermsModel", b =>
                {
                    b.HasOne("CRM.Api.Models.Masters.CountryModel", "CountryofOriginModel")
                        .WithMany()
                        .HasForeignKey("CountryofOriginId");

                    b.HasOne("CRM.Api.Models.Masters.CurrencyModel", "CurrencyModel")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("CRM.Api.Models.Masters.DeliveredToModel", "DeliveredToModel")
                        .WithMany()
                        .HasForeignKey("DelieveryNameId");

                    b.HasOne("CRM.Api.Models.Masters.DeliveryTimeModel", "DeliveryTimeModel")
                        .WithMany()
                        .HasForeignKey("DeliveryTimeId");

                    b.HasOne("CRM.Api.Models.Masters.MtcTypeModel", "MtcTypeModel")
                        .WithMany()
                        .HasForeignKey("MtcTypeId");

                    b.HasOne("CRM.Api.Models.Masters.TransportModeModel", "PackingTypeModel")
                        .WithMany()
                        .HasForeignKey("PackingTypeId");

                    b.HasOne("CRM.Api.Models.Masters.PaymentTypeModel", "PaymentTypeModel")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("CRM.Api.Models.Masters.ValidityModel", "ValidityModel")
                        .WithMany()
                        .HasForeignKey("ValidityId");

                    b.Navigation("CountryofOriginModel");

                    b.Navigation("CurrencyModel");

                    b.Navigation("DeliveredToModel");

                    b.Navigation("DeliveryTimeModel");

                    b.Navigation("MtcTypeModel");

                    b.Navigation("PackingTypeModel");

                    b.Navigation("PaymentTypeModel");

                    b.Navigation("ValidityModel");
                });

            modelBuilder.Entity("CRM.Api.Models.Quotation.QuotationModel", b =>
                {
                    b.Navigation("QuotationItems");
                });
#pragma warning restore 612, 618
        }
    }
}

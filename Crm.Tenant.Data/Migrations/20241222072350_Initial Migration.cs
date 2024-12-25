using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hsn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HsnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hsn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MtcTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MtcType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuotationCloseReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationCloseReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationCloseReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportModes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Validities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Validity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GstNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsWhatsApp = table.Column<bool>(type: "bit", nullable: true),
                    SkypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveredTo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportModeId = table.Column<int>(type: "int", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveredTo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveredTo_TransportModes_TransportModeId",
                        column: x => x.TransportModeId,
                        principalTable: "TransportModes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendorMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsWhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    SkypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMainSeller = table.Column<bool>(type: "bit", nullable: false),
                    PMOC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorMember_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationMadeById = table.Column<int>(type: "int", nullable: true),
                    QuotationAssignedToId = table.Column<int>(type: "int", nullable: true),
                    QuotationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuotationCompanyId = table.Column<int>(type: "int", nullable: true),
                    QuotationAttentionId = table.Column<int>(type: "int", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationPriority = table.Column<int>(type: "int", nullable: false),
                    QuotationStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationImportance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationCloseReasonId = table.Column<int>(type: "int", nullable: true),
                    GstPercent = table.Column<double>(type: "float", nullable: true),
                    NetTotal = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GstAmount = table.Column<double>(type: "float", nullable: true),
                    OtherCharges = table.Column<double>(type: "float", nullable: true),
                    GrandTotal = table.Column<double>(type: "float", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_Clients_QuotationCompanyId",
                        column: x => x.QuotationCompanyId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_Members_QuotationAttentionId",
                        column: x => x.QuotationAttentionId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_QuotationCloseReasons_QuotationCloseReasonId",
                        column: x => x.QuotationCloseReasonId,
                        principalTable: "QuotationCloseReasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_Users_QuotationAssignedToId",
                        column: x => x.QuotationAssignedToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_Users_QuotationMadeById",
                        column: x => x.QuotationMadeById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderMadeById = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderAssignedToId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderVendorId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderAttentionId = table.Column<int>(type: "int", nullable: true),
                    GstPercent = table.Column<double>(type: "float", nullable: true),
                    NetTotal = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GstAmount = table.Column<double>(type: "float", nullable: true),
                    OtherCharges = table.Column<double>(type: "float", nullable: true),
                    GrandTotal = table.Column<double>(type: "float", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_PurchaseOrderAssignedToId",
                        column: x => x.PurchaseOrderAssignedToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_PurchaseOrderMadeById",
                        column: x => x.PurchaseOrderMadeById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Vendor_PurchaseOrderVendorId",
                        column: x => x.PurchaseOrderVendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_VendorMember_PurchaseOrderAttentionId",
                        column: x => x.PurchaseOrderAttentionId,
                        principalTable: "VendorMember",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuotationFollowUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    SrNo = table.Column<int>(type: "int", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextFollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FollowUpDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowUpRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationFollowUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationFollowUp_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    SrNo = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Margin = table.Column<double>(type: "float", nullable: false),
                    PackagingCharges = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationItems_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<int>(type: "int", nullable: true),
                    DeliveryNameId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    DeliveryTimeId = table.Column<int>(type: "int", nullable: true),
                    CountryofOriginId = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    MtcTypeId = table.Column<int>(type: "int", nullable: true),
                    ValidityId = table.Column<int>(type: "int", nullable: true),
                    PackingTypeId = table.Column<int>(type: "int", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationTerms_Countries_CountryofOriginId",
                        column: x => x.CountryofOriginId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationTerms_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationTerms_DeliveredTo_DeliveryNameId",
                        column: x => x.DeliveryNameId,
                        principalTable: "DeliveredTo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationTerms_DeliveryTime_DeliveryTimeId",
                        column: x => x.DeliveryTimeId,
                        principalTable: "DeliveryTime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationTerms_MtcTypes_MtcTypeId",
                        column: x => x.MtcTypeId,
                        principalTable: "MtcTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationTerms_PaymentTypes_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationTerms_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationTerms_TransportModes_PackingTypeId",
                        column: x => x.PackingTypeId,
                        principalTable: "TransportModes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuotationTerms_Validities_ValidityId",
                        column: x => x.ValidityId,
                        principalTable: "Validities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    SrNo = table.Column<int>(type: "int", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hsn = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_Hsn_Hsn",
                        column: x => x.Hsn,
                        principalTable: "Hsn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    DeliveryNameId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    DeliveryTimeId = table.Column<int>(type: "int", nullable: true),
                    CountryofOriginId = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    MtcTypeId = table.Column<int>(type: "int", nullable: true),
                    ValidityId = table.Column<int>(type: "int", nullable: true),
                    PackingTypeId = table.Column<int>(type: "int", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_Countries_CountryofOriginId",
                        column: x => x.CountryofOriginId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_DeliveredTo_DeliveryNameId",
                        column: x => x.DeliveryNameId,
                        principalTable: "DeliveredTo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_DeliveryTime_DeliveryTimeId",
                        column: x => x.DeliveryTimeId,
                        principalTable: "DeliveryTime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_MtcTypes_MtcTypeId",
                        column: x => x.MtcTypeId,
                        principalTable: "MtcTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_PaymentTypes_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_TransportModes_PackingTypeId",
                        column: x => x.PackingTypeId,
                        principalTable: "TransportModes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderTerms_Validities_ValidityId",
                        column: x => x.ValidityId,
                        principalTable: "Validities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveredTo_TransportModeId",
                table: "DeliveredTo",
                column: "TransportModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClientId",
                table: "Members",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_Hsn",
                table: "PurchaseOrderItems",
                column: "Hsn");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_PurchaseOrderId",
                table: "PurchaseOrderItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderAssignedToId",
                table: "PurchaseOrders",
                column: "PurchaseOrderAssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderAttentionId",
                table: "PurchaseOrders",
                column: "PurchaseOrderAttentionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderMadeById",
                table: "PurchaseOrders",
                column: "PurchaseOrderMadeById");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderVendorId",
                table: "PurchaseOrders",
                column: "PurchaseOrderVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_CountryofOriginId",
                table: "PurchaseOrderTerms",
                column: "CountryofOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_CurrencyId",
                table: "PurchaseOrderTerms",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_DeliveryNameId",
                table: "PurchaseOrderTerms",
                column: "DeliveryNameId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_DeliveryTimeId",
                table: "PurchaseOrderTerms",
                column: "DeliveryTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_MtcTypeId",
                table: "PurchaseOrderTerms",
                column: "MtcTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_PackingTypeId",
                table: "PurchaseOrderTerms",
                column: "PackingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_PaymentId",
                table: "PurchaseOrderTerms",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_PurchaseOrderId",
                table: "PurchaseOrderTerms",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_ValidityId",
                table: "PurchaseOrderTerms",
                column: "ValidityId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationFollowUp_QuotationId",
                table: "QuotationFollowUp",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_QuotationId",
                table: "QuotationItems",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationAssignedToId",
                table: "Quotations",
                column: "QuotationAssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationAttentionId",
                table: "Quotations",
                column: "QuotationAttentionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationCloseReasonId",
                table: "Quotations",
                column: "QuotationCloseReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationCompanyId",
                table: "Quotations",
                column: "QuotationCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationMadeById",
                table: "Quotations",
                column: "QuotationMadeById");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_CountryofOriginId",
                table: "QuotationTerms",
                column: "CountryofOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_CurrencyId",
                table: "QuotationTerms",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_DeliveryNameId",
                table: "QuotationTerms",
                column: "DeliveryNameId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_DeliveryTimeId",
                table: "QuotationTerms",
                column: "DeliveryTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_MtcTypeId",
                table: "QuotationTerms",
                column: "MtcTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_PackingTypeId",
                table: "QuotationTerms",
                column: "PackingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_PaymentId",
                table: "QuotationTerms",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_QuotationId",
                table: "QuotationTerms",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_ValidityId",
                table: "QuotationTerms",
                column: "ValidityId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorMember_VendorId",
                table: "VendorMember",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrderTerms");

            migrationBuilder.DropTable(
                name: "QuotationFollowUp");

            migrationBuilder.DropTable(
                name: "QuotationItems");

            migrationBuilder.DropTable(
                name: "QuotationTerms");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Hsn");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "DeliveredTo");

            migrationBuilder.DropTable(
                name: "DeliveryTime");

            migrationBuilder.DropTable(
                name: "MtcTypes");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "Validities");

            migrationBuilder.DropTable(
                name: "VendorMember");

            migrationBuilder.DropTable(
                name: "TransportModes");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "QuotationCloseReasons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

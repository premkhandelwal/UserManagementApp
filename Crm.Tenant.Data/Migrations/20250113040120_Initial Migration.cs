using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurrencyName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrencyRate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeliveryTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeliveryTime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTime", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hsn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HsnName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hsn", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaterialName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MtcTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MtcType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtcTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PaymentType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuotationCloseReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuotationCloseReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationCloseReasons", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransportModes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransportMode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportModes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UnitName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MobileNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Validities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Validity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VendorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GstNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    MemberName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsWhatsApp = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    SkypeId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeliveredTo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeliveryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransportModeId = table.Column<int>(type: "int", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveredTo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveredTo_TransportModes_TransportModeId",
                        column: x => x.TransportModeId,
                        principalTable: "TransportModes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VendorMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    MemberName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Designation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsWhatsApp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SkypeId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMainSeller = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PMOC = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorMember_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuotationMadeById = table.Column<int>(type: "int", nullable: true),
                    QuotationAssignedToId = table.Column<int>(type: "int", nullable: true),
                    QuotationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    QuotationCompanyId = table.Column<int>(type: "int", nullable: true),
                    QuotationAttentionId = table.Column<int>(type: "int", nullable: true),
                    Reference = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuotationPriority = table.Column<int>(type: "int", nullable: false),
                    QuotationStage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuotationImportance = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuotationStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuotationCloseReasonId = table.Column<int>(type: "int", nullable: true),
                    GstPercent = table.Column<double>(type: "double", nullable: true),
                    NetTotal = table.Column<double>(type: "double", nullable: true),
                    Discount = table.Column<double>(type: "double", nullable: true),
                    DiscountType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GstAmount = table.Column<double>(type: "double", nullable: true),
                    OtherCharges = table.Column<double>(type: "double", nullable: true),
                    GrandTotal = table.Column<double>(type: "double", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseOrderMadeById = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderAssignedToId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PurchaseOrderVendorId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderAttentionId = table.Column<int>(type: "int", nullable: true),
                    GstPercent = table.Column<double>(type: "double", nullable: true),
                    NetTotal = table.Column<double>(type: "double", nullable: true),
                    Discount = table.Column<double>(type: "double", nullable: true),
                    DiscountType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GstAmount = table.Column<double>(type: "double", nullable: true),
                    OtherCharges = table.Column<double>(type: "double", nullable: true),
                    GrandTotal = table.Column<double>(type: "double", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuotationFollowUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    SrNo = table.Column<int>(type: "int", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NextFollowUpDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FollowUpDetails = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FollowUpRemarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuotationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    SrNo = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<double>(type: "double", nullable: false),
                    Unit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cost = table.Column<double>(type: "double", nullable: false),
                    Margin = table.Column<double>(type: "double", nullable: false),
                    PackagingCharges = table.Column<double>(type: "double", nullable: false),
                    UnitPrice = table.Column<double>(type: "double", nullable: false),
                    TotalPrice = table.Column<double>(type: "double", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuotationTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuotationId = table.Column<int>(type: "int", nullable: true),
                    DeliveryNameId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    DeliveryTimeId = table.Column<int>(type: "int", nullable: true),
                    CountryofOriginId = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    MtcTypeId = table.Column<int>(type: "int", nullable: true),
                    ValidityId = table.Column<int>(type: "int", nullable: true),
                    PackingTypeId = table.Column<int>(type: "int", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    SrNo = table.Column<int>(type: "int", nullable: false),
                    Description1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<double>(type: "double", nullable: false),
                    Unit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hsn = table.Column<int>(type: "int", nullable: true),
                    DeliveryStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitPrice = table.Column<double>(type: "double", nullable: false),
                    TotalPrice = table.Column<double>(type: "double", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    DeliveryNameId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    DeliveryTimeId = table.Column<int>(type: "int", nullable: true),
                    CountryofOriginId = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    MtcTypeId = table.Column<int>(type: "int", nullable: true),
                    ValidityId = table.Column<int>(type: "int", nullable: true),
                    PackingTypeId = table.Column<int>(type: "int", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

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
                name: "QuotationTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    DelieveryNameId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    DeliveryTimeId = table.Column<int>(type: "int", nullable: true),
                    CountryofOriginId = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    MtcTypeId = table.Column<int>(type: "int", nullable: true),
                    ValidityId = table.Column<int>(type: "int", nullable: true),
                    PackingTypeId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_QuotationTerms_DeliveredTo_DelieveryNameId",
                        column: x => x.DelieveryNameId,
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
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationMadeById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationAssignedToId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuotationStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationCompanyId = table.Column<int>(type: "int", nullable: true),
                    QuotationAttentionId = table.Column<int>(type: "int", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationImportance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationPriority = table.Column<int>(type: "int", nullable: false),
                    GstPercent = table.Column<double>(type: "float", nullable: false),
                    NetTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GstAmount = table.Column<double>(type: "float", nullable: false),
                    OtherCharges = table.Column<double>(type: "float", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    QuotationTermsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_QuotationTerms_QuotationTermsId",
                        column: x => x.QuotationTermsId,
                        principalTable: "QuotationTerms",
                        principalColumn: "Id");
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
                    QuotationModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationItems_Quotations_QuotationModelId",
                        column: x => x.QuotationModelId,
                        principalTable: "Quotations",
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
                name: "IX_QuotationItems_QuotationModelId",
                table: "QuotationItems",
                column: "QuotationModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationTermsId",
                table: "Quotations",
                column: "QuotationTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_CountryofOriginId",
                table: "QuotationTerms",
                column: "CountryofOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_CurrencyId",
                table: "QuotationTerms",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_DelieveryNameId",
                table: "QuotationTerms",
                column: "DelieveryNameId");

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
                name: "IX_QuotationTerms_ValidityId",
                table: "QuotationTerms",
                column: "ValidityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "QuotationCloseReasons");

            migrationBuilder.DropTable(
                name: "QuotationItems");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "QuotationTerms");

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
                name: "Validities");

            migrationBuilder.DropTable(
                name: "TransportModes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class AddedPurchaseOrdertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuotationMadeById",
                table: "Quotations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuotationAssignedToId",
                table: "Quotations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                    HsnId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_PurchaseOrderItems_Hsn_HsnId",
                        column: x => x.HsnId,
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
                name: "IX_Quotations_QuotationAssignedToId",
                table: "Quotations",
                column: "QuotationAssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationAttentionId",
                table: "Quotations",
                column: "QuotationAttentionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationCompanyId",
                table: "Quotations",
                column: "QuotationCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationMadeById",
                table: "Quotations",
                column: "QuotationMadeById");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_HsnId",
                table: "PurchaseOrderItems",
                column: "HsnId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Clients_QuotationCompanyId",
                table: "Quotations",
                column: "QuotationCompanyId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Members_QuotationAttentionId",
                table: "Quotations",
                column: "QuotationAttentionId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_QuotationAssignedToId",
                table: "Quotations",
                column: "QuotationAssignedToId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_QuotationMadeById",
                table: "Quotations",
                column: "QuotationMadeById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Clients_QuotationCompanyId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Members_QuotationAttentionId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_QuotationAssignedToId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_QuotationMadeById",
                table: "Quotations");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrderTerms");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationAssignedToId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationAttentionId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationCompanyId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationMadeById",
                table: "Quotations");

            migrationBuilder.AlterColumn<string>(
                name: "QuotationMadeById",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuotationAssignedToId",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

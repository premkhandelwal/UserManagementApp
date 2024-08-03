using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Api.Migrations
{
    public partial class ShiftedNetTotalDiscountOtherchargestoMainQuotationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "GstAmount",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "OtherCharges",
                table: "QuotationItems");

            migrationBuilder.RenameColumn(
                name: "QuotationCompanyMemberId",
                table: "Quotations",
                newName: "QuotationAttentionId");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Quotations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "DiscountType",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GrandTotal",
                table: "Quotations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GstAmount",
                table: "Quotations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NetTotal",
                table: "Quotations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OtherCharges",
                table: "Quotations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "GstAmount",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "OtherCharges",
                table: "Quotations");

            migrationBuilder.RenameColumn(
                name: "QuotationAttentionId",
                table: "Quotations",
                newName: "QuotationCompanyMemberId");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "QuotationItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "DiscountType",
                table: "QuotationItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GrandTotal",
                table: "QuotationItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GstAmount",
                table: "QuotationItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NetTotal",
                table: "QuotationItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OtherCharges",
                table: "QuotationItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

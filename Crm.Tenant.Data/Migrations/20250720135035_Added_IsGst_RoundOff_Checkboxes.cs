using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Added_IsGst_RoundOff_Checkboxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGstRemoved",
                table: "Quotations",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRoundOff",
                table: "Quotations",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGstRemoved",
                table: "PurchaseOrders",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRoundOff",
                table: "PurchaseOrders",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGstRemoved",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "IsRoundOff",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "IsGstRemoved",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IsRoundOff",
                table: "PurchaseOrders");
        }
    }
}

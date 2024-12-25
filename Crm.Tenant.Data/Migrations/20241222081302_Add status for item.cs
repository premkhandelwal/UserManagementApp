using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Addstatusforitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryStatus",
                table: "PurchaseOrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "PurchaseOrderItems");
        }
    }
}

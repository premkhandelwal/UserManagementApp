using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Inward_Quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "PurchaseOrderItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "QuotationFollowUpDate",
                table: "Quotations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InwardQuantity",
                table: "PurchaseOrderItems",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotationFollowUpDate",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "InwardQuantity",
                table: "PurchaseOrderItems");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryStatus",
                table: "PurchaseOrderItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

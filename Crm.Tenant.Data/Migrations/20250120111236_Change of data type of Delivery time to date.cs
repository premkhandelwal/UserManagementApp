using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class ChangeofdatatypeofDeliverytimetodate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderTerms_DeliveryTime_DeliveryTimeId",
                table: "PurchaseOrderTerms");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderTerms_DeliveryTimeId",
                table: "PurchaseOrderTerms");

            migrationBuilder.DropColumn(
                name: "DeliveryTimeId",
                table: "PurchaseOrderTerms");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryTime",
                table: "PurchaseOrderTerms",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "PurchaseOrderTerms");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTimeId",
                table: "PurchaseOrderTerms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderTerms_DeliveryTimeId",
                table: "PurchaseOrderTerms",
                column: "DeliveryTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderTerms_DeliveryTime_DeliveryTimeId",
                table: "PurchaseOrderTerms",
                column: "DeliveryTimeId",
                principalTable: "DeliveryTime",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Change_PartNumber_to_PartNumberId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderItemModel_PartNumbers_PartNumber",
                table: "WorkOrderItemModel");

            migrationBuilder.RenameColumn(
                name: "PartNumber",
                table: "WorkOrderItemModel",
                newName: "PartNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderItemModel_PartNumber",
                table: "WorkOrderItemModel",
                newName: "IX_WorkOrderItemModel_PartNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderItemModel_PartNumbers_PartNumberId",
                table: "WorkOrderItemModel",
                column: "PartNumberId",
                principalTable: "PartNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderItemModel_PartNumbers_PartNumberId",
                table: "WorkOrderItemModel");

            migrationBuilder.RenameColumn(
                name: "PartNumberId",
                table: "WorkOrderItemModel",
                newName: "PartNumber");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderItemModel_PartNumberId",
                table: "WorkOrderItemModel",
                newName: "IX_WorkOrderItemModel_PartNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderItemModel_PartNumbers_PartNumber",
                table: "WorkOrderItemModel",
                column: "PartNumber",
                principalTable: "PartNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

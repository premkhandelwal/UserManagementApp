using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Added_Remark_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderItemModel_PartNumbers_PartNumberId",
                table: "WorkOrderItemModel");

            migrationBuilder.AlterColumn<int>(
                name: "PartNumberId",
                table: "WorkOrderItemModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "WorkOrderFieldsModel",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderItemModel_PartNumbers_PartNumberId",
                table: "WorkOrderItemModel",
                column: "PartNumberId",
                principalTable: "PartNumbers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderItemModel_PartNumbers_PartNumberId",
                table: "WorkOrderItemModel");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "WorkOrderFieldsModel");

            migrationBuilder.AlterColumn<int>(
                name: "PartNumberId",
                table: "WorkOrderItemModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderItemModel_PartNumbers_PartNumberId",
                table: "WorkOrderItemModel",
                column: "PartNumberId",
                principalTable: "PartNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

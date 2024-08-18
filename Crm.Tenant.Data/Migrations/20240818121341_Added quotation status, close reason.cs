using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Addedquotationstatusclosereason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuotationCloseReasonId",
                table: "Quotations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuotationStatus",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuotationCloseReason",
                table: "QuotationCloseReasons",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationCloseReasonId",
                table: "Quotations",
                column: "QuotationCloseReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_QuotationCloseReasons_QuotationCloseReasonId",
                table: "Quotations",
                column: "QuotationCloseReasonId",
                principalTable: "QuotationCloseReasons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_QuotationCloseReasons_QuotationCloseReasonId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationCloseReasonId",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "QuotationCloseReasonId",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "QuotationStatus",
                table: "Quotations");

            migrationBuilder.AlterColumn<string>(
                name: "QuotationCloseReason",
                table: "QuotationCloseReasons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

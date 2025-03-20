using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Removed_SrNo_FollowUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SrNo",
                table: "QuotationFollowUp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "QuotationFollowUpDate",
                table: "Quotations",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "QuotationFollowUpDate",
                table: "Quotations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SrNo",
                table: "QuotationFollowUp",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

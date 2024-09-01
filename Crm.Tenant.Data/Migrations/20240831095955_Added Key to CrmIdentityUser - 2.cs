using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class AddedKeytoCrmIdentityUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CrmIdentityUser_UserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrmIdentityUser",
                table: "CrmIdentityUser");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CrmIdentityUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CrmIdentityUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrmIdentityUser",
                table: "CrmIdentityUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CrmIdentityUser_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "CrmIdentityUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CrmIdentityUser_UserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrmIdentityUser",
                table: "CrmIdentityUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CrmIdentityUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CrmIdentityUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrmIdentityUser",
                table: "CrmIdentityUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CrmIdentityUser_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "CrmIdentityUser",
                principalColumn: "UserId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Admin.Data.Migrations
{
    public partial class AddedIsDeactivatedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeactivated",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeactivated",
                table: "AspNetUsers");
        }
    }
}

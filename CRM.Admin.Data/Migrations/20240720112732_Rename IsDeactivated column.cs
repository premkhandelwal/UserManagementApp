using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementData.Migrations
{
    public partial class RenameIsDeactivatedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeactivated",
                table: "AspNetUsers",
                newName: "IsDeactivated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeactivated",
                table: "AspNetUsers",
                newName: "isDeactivated");
        }
    }
}

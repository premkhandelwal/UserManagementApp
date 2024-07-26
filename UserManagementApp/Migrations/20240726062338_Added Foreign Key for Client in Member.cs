using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApp.Migrations
{
    public partial class AddedForeignKeyforClientinMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveredTo_TransportModes_TransportModeId",
                table: "DeliveredTo");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clients_ClientId",
                table: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Members",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TransportModeId",
                table: "DeliveredTo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveredTo_TransportModes_TransportModeId",
                table: "DeliveredTo",
                column: "TransportModeId",
                principalTable: "TransportModes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Clients_ClientId",
                table: "Members",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveredTo_TransportModes_TransportModeId",
                table: "DeliveredTo");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Clients_ClientId",
                table: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Members",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransportModeId",
                table: "DeliveredTo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveredTo_TransportModes_TransportModeId",
                table: "DeliveredTo",
                column: "TransportModeId",
                principalTable: "TransportModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Clients_ClientId",
                table: "Members",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

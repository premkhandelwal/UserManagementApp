using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Rename_PurchaseOrderName_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchareOrderNumber",
                table: "WorkOrderFieldsModel",
                newName: "PurchaseOrderNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseOrderNumber",
                table: "WorkOrderFieldsModel",
                newName: "PurchareOrderNumber");
        }
    }
}

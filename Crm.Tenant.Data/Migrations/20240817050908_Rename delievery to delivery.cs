using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Renamedelieverytodelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotationTerms_DeliveredTo_DelieveryNameId",
                table: "QuotationTerms");

            migrationBuilder.RenameColumn(
                name: "DelieveryNameId",
                table: "QuotationTerms",
                newName: "DeliveryNameId");

            
            migrationBuilder.AddForeignKey(
                name: "FK_QuotationTerms_DeliveredTo_DeliveryNameId",
                table: "QuotationTerms",
                column: "DeliveryNameId",
                principalTable: "DeliveredTo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotationTerms_DeliveredTo_DeliveryNameId",
                table: "QuotationTerms");

            migrationBuilder.RenameColumn(
                name: "DeliveryNameId",
                table: "QuotationTerms",
                newName: "DelieveryNameId");

            // Manually rename the index back
            migrationBuilder.Sql("EXEC sp_rename N'[QuotationTerms].[IX_QuotationTerms_DeliveryNameId]', N'IX_QuotationTerms_DelieveryNameId', N'INDEX'");

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationTerms_DeliveredTo_DelieveryNameId",
                table: "QuotationTerms",
                column: "DelieveryNameId",
                principalTable: "DeliveredTo",
                principalColumn: "Id");
        }
    }
}

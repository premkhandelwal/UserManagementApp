using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class AddedModifiedOnAddedOninQuotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationModelId",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_QuotationTerms_QuotationTermsId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationTermsId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_QuotationItems_QuotationModelId",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "QuotationTermsId",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "QuotationModelId",
                table: "QuotationItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "QuotationTerms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QuotationTerms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "QuotationTerms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Quotations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Quotations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Quotations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "QuotationItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QuotationItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "QuotationItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuotationTerms_QuotationId",
                table: "QuotationTerms",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_QuotationId",
                table: "QuotationItems",
                column: "QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationId",
                table: "QuotationItems",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationTerms_Quotations_QuotationId",
                table: "QuotationTerms",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationId",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationTerms_Quotations_QuotationId",
                table: "QuotationTerms");

            migrationBuilder.DropIndex(
                name: "IX_QuotationTerms_QuotationId",
                table: "QuotationTerms");

            migrationBuilder.DropIndex(
                name: "IX_QuotationItems_QuotationId",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "QuotationTerms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QuotationTerms");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "QuotationTerms");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "QuotationItems");

            migrationBuilder.AddColumn<int>(
                name: "QuotationTermsId",
                table: "Quotations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuotationModelId",
                table: "QuotationItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationTermsId",
                table: "Quotations",
                column: "QuotationTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_QuotationModelId",
                table: "QuotationItems",
                column: "QuotationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationModelId",
                table: "QuotationItems",
                column: "QuotationModelId",
                principalTable: "Quotations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_QuotationTerms_QuotationTermsId",
                table: "Quotations",
                column: "QuotationTermsId",
                principalTable: "QuotationTerms",
                principalColumn: "Id");
        }
    }
}

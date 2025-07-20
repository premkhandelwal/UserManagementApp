using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Tenant.Data.Migrations
{
    public partial class Added_CreatedOn_ModifiedOn_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "WorkOrderStatusModel",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "WorkOrderStatusModel",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "WorkOrderItemModel",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "WorkOrderItemModel",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "WorkOrderFieldsModel",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "WorkOrderFieldsModel",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "VendorMember",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "VendorMember",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Vendor",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Vendor",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Validities",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Validities",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Units",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Units",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "TransportModes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TransportModes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "QuotationTerms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "QuotationTerms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Quotations",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Quotations",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "QuotationItems",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "QuotationItems",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "QuotationFollowUp",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "QuotationFollowUp",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "QuotationCloseReasons",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "QuotationCloseReasons",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "PurchaseOrderTerms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PurchaseOrderTerms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "PurchaseOrders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PurchaseOrders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "PurchaseOrderItems",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PurchaseOrderItems",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Products",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Products",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "PaymentTypes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PaymentTypes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "PartNumbers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PartNumbers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "MtcTypes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "MtcTypes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Members",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Members",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Materials",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Materials",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Hsn",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Hsn",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "DeliveryTime",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "DeliveryTime",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "DeliveredTo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "DeliveredTo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Currencies",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Currencies",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Countries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Countries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Clients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Clients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "WorkOrderStatusModel");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "WorkOrderStatusModel");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "WorkOrderItemModel");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "WorkOrderItemModel");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "WorkOrderFieldsModel");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "WorkOrderFieldsModel");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "VendorMember");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VendorMember");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Validities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Validities");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "TransportModes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TransportModes");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "QuotationTerms");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "QuotationTerms");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "QuotationFollowUp");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "QuotationFollowUp");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "QuotationCloseReasons");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "QuotationCloseReasons");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PurchaseOrderTerms");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PurchaseOrderTerms");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PartNumbers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PartNumbers");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "MtcTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "MtcTypes");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Hsn");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Hsn");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "DeliveryTime");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "DeliveryTime");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "DeliveredTo");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "DeliveredTo");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Clients");
        }
    }
}

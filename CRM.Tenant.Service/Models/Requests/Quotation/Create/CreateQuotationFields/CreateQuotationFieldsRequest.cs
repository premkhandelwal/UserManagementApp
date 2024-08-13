﻿using CRM.Tenant.Service.Services;

namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields
{
    public class CreateQuotationFieldsRequest
    {
        public string? QuotationMadeById { get; set; }

        public string? QuotationAssignedToId { get; set; }

        public DateTime QuotationDate { get; set; }

        public string? QuotationStage { get; set; }

        public int? QuotationCompanyId { get; set; }

        public int? QuotationAttentionId { get; set; }

        public string? Reference { get; set; }

        public string? QuotationImportance { get; set; }

        public int QuotationPriority { get; set; }

        public double GstPercent { get; set; }

        public double NetTotal { get; set; }

        public double Discount { get; set; }

        public string? DiscountType { get; set; }

        public double GstAmount { get; set; }

        public double OtherCharges { get; set; }

        public double GrandTotal { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

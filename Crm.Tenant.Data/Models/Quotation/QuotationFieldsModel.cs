﻿using Crm.Admin.Service.Models;
using Crm.Tenant.Data.Models.Masters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.Quotation
{
    public class QuotationFieldsModel: BaseModelClass
    {
        public string? QuotationId { get; set; }
        public int? QuotationMadeById { get; set; }

        public int? QuotationAssignedToId { get; set; }

        public DateTime QuotationDate { get; set; }

        public DateTime? QuotationFollowUpDate { get; set; }

        public int? QuotationCompanyId { get; set; }

        public int? QuotationAttentionId { get; set; }

        public string? Reference { get; set; }

        public int QuotationPriority { get; set; }

        public string? QuotationStage { get; set; }
        
        public string? QuotationImportance { get; set; }

        public string? QuotationStatus { get; set; } = "Open";

        public int? QuotationCloseReasonId { get; set; }

        public double? GstPercent { get; set; }

        public double? NetTotal { get; set; }

        public double? Discount { get; set; }

        public string? DiscountType { get; set; }

        public double? GstAmount { get; set; }

        public double? OtherCharges { get; set; }

        public double? GrandTotal { get; set; }
        
        public bool? IsRoundOff { get; set; }
        public bool? IsGstRemoved { get; set; }

        [ForeignKey(nameof(QuotationMadeById))]
        public virtual UserModel? QuotationMadeByUserModel { get; set; }

        [ForeignKey(nameof(QuotationAssignedToId))]
        public virtual UserModel? QuotationAssignedToUserModel { get; set; }

        [ForeignKey(nameof(QuotationCompanyId))]
        public virtual ClientModel? QuotationCompanyModel { get; set; }

        [ForeignKey(nameof(QuotationAttentionId))]
        public virtual MemberModel? QuotationAttentionModel { get; set; }

        [ForeignKey(nameof(QuotationCloseReasonId))]
        public virtual QuotationCloseReasonModel? QuotationCloseReasonsModel { get; set; }
    }
}

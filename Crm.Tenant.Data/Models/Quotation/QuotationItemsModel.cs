﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Crm.Tenant.Data.Models;

namespace Crm.Api.Models.Quotation
{
    public class QuotationItemModel: BaseModelClass
    {
        public int QuotationId { get; set; } 

        public int SrNo { get; set; }

        public string? Description { get; set; }

        public double Quantity { get; set; }

        public string? Unit { get; set; }

        public double Cost { get; set; }

        public double Margin { get; set; }

        public double PackagingCharges { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        [ForeignKey(nameof(QuotationId))]
        public QuotationFieldsModel? QuotationFieldsModel { get; set; }
    }
}

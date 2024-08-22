using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Crm.Api.Models.Quotation;
using Crm.Tenant.Data.Models.Masters;

namespace Crm.Tenant.Data.Models
{
    public class BaseModelClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool IsModelReferenced(IEnumerable<QuotationFieldsModel> quotations)
        {
            return quotations.Any(quotation => quotation.QuotationCompanyId == Id);
        }

    }
}

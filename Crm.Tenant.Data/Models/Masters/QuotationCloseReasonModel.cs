using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Crm.Tenant.Data.Models.Masters;

namespace CRM.Data.Models.Masters
{
    public class QuotationCloseReasonModel: BaseModelClass
    {
        public string? QuotationCloseReason { get; set; }
    }
}

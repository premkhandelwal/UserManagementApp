using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class QuotationCloseReasonModel: BaseModelClass
    {
        public string? QuotationCloseReason { get; set; }
    }
}

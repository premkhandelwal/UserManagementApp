using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class PaymentTypeModel: BaseModelClass
    {
        public string? PaymentType { get; set; }
    }
}

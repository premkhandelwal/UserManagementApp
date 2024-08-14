using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class CurrencyModel: BaseModelClass
    {
        public string? CurrencyName { get; set; }
        public string? CurrencyRate { get; set; }
    }
}

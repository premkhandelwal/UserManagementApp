using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class ProductModel: BaseModelClass
    {
        public string? ProductName { get; set; }
    }
}

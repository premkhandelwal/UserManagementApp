using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class MaterialModel: BaseModelClass
    {
        public string? MaterialName { get; set; }
    }
}

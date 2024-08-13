using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class CountryModel : BaseModelClass
    {
        public string? CountryName { get; set; }
    }
}

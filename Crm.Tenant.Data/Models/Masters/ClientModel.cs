using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.Masters
{
    public class ClientModel: BaseModelClass
    {
        public string? CompanyName { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Website { get; set; }
    }
}

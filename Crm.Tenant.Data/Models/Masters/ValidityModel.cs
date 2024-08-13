using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class ValidityModel: BaseModelClass
    {
        public string? Validity { get; set; }
    }
}

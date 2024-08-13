using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class MtcTypeModel: BaseModelClass
    {
        public string? MtcType { get; set; }
    }
}

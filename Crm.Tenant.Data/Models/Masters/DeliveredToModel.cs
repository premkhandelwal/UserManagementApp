using Crm.Tenant.Data.Models.Masters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.Masters
{
    public class DeliveredToModel: BaseModelClass
    {
        public string? DeliveryName { get; set; }
        public int? TransportModeId { get; set; }

        [ForeignKey(nameof(TransportModeId))]
        public virtual TransportModeModel? TransportMode { get; set; }
    }

}

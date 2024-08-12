using Crm.Tenant.Service.Models.Requests.MtcType.CreateMtcType;

namespace Crm.Tenant.Service.Models.Requests.MtcType.UpdateMtcType
{
    public class UpdateMtcTypeRequest : CreateMtcTypeRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

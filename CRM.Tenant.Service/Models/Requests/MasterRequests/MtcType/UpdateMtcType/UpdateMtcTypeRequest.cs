using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.UpdateMtcType
{
    public class UpdateMtcTypeRequest : CreateMtcTypeRequest
    {
        public int? Id { get; set; }
    }
}

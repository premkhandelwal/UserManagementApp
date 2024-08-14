using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.DeleteMtcType
{
    public class DeleteMtcTypeRequest : CreateMtcTypeRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }

    }
}

using CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.CreateHsn;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.UpdateHsn
{
    public class UpdateHsnRequest: CreateHsnRequest
    {
        public int? Id { get; set; }
    }
}

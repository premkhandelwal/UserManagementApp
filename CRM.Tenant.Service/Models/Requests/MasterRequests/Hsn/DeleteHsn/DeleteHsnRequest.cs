using CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.CreateHsn;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.DeleteHsn
{
    public class DeleteHsnRequest: CreateHsnRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

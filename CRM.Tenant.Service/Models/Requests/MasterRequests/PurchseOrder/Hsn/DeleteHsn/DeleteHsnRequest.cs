using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.CreateHsn;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.DeleteHsn
{
    public class DeleteHsnRequest : CreateHsnRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

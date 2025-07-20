using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.CreatePartNumber;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.DeletePartNumber
{
    public class DeletePartNumberRequest: CreatePartNumberRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

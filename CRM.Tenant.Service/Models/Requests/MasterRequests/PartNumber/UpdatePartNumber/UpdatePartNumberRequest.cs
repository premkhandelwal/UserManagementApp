using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.CreatePartNumber;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.UpdatePartNumber
{
    public class UpdatePartNumberRequest : CreatePartNumberRequest
    {
        public int? Id { get; set; }
    }
}

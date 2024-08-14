using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.DeleteValidity
{
    public class DeleteValidityRequest : CreateValidityRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

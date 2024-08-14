using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.UpdateValidity
{
    public class UpdateValidityRequest : CreateValidityRequest
    {
        public int? Id { get; set; }
    }
}

using Crm.Tenant.Service.Models.Requests.Validity.CreateValidity;

namespace Crm.Tenant.Service.Models.Requests.Validity.UpdateValidity
{
    public class UpdateValidityRequest : CreateValidityRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

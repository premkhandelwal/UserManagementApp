using Crm.Tenant.Service.Models.Requests.Validity.CreateValidity;

namespace Crm.Tenant.Service.Models.Requests.Validity.DeleteValidity
{
    public class DeleteValidityRequest : CreateValidityRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

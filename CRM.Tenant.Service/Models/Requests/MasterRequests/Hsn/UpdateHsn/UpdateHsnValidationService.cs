using CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.CreateHsn;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.UpdateHsn;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.UpdateDeliveredTo
{
    public class UpdateHsnValidationService : CreateHsnValidationService<UpdateHsnRequest>
    {
        public UpdateHsnValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

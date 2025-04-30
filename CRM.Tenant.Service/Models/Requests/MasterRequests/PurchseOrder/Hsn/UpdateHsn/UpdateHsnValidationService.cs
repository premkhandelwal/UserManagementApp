using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.CreateHsn;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.UpdateHsn
{
    public class UpdateHsnValidationService : CreateHsnValidationService<UpdateHsnRequest>
    {
        public UpdateHsnValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

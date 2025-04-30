using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Create;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Update;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.UpdateClient
{
    public class UpdateQuotationFollowUpValidationService : CreateQuotationFollowUpValidationService<UpdateQuotationFollowUpRequest>
    {
        public UpdateQuotationFollowUpValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }

}

using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.Clients.UpdateClient;
using FluentValidation;

namespace Crm.Tenant.Service.Services.Models.Requests.Clients.UpdateClient
{
    public class UpdateClientValidationService : CreateClientValidationService<UpdateClientRequest>
    {
        public UpdateClientValidationService() {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }

}

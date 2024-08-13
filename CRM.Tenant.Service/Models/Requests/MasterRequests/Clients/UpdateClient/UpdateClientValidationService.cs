using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.UpdateClient
{
    public class UpdateClientValidationService : CreateClientValidationService<UpdateClientRequest>
    {
        public UpdateClientValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }

}

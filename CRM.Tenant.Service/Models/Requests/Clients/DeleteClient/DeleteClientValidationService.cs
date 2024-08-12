using Crm.Tenant.Service.Models.Requests.Clients.CreateClient;
using Crm.Tenant.Service.Models.Requests.Clients.DeleteClient;
using FluentValidation;

namespace Crm.Tenant.Service.Services.Models.Requests.Clients.DeleteClient
{
    public class DeleteClientValidationService : CreateClientValidationService<DeleteClientRequest>
    {
        public DeleteClientValidationService() {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }

}

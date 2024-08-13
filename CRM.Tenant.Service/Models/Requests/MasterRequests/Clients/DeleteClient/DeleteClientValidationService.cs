using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.DeleteClient
{
    public class DeleteClientValidationService : CreateClientValidationService<DeleteClientRequest>
    {
        public DeleteClientValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }

}

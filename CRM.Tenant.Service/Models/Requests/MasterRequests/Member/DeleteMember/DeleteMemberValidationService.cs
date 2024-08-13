using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Member.DeleteMember
{
    public class DeleteMemberValidationService : CreateMemberValidationService<DeleteMemberRequest>
    {
        public DeleteMemberValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}

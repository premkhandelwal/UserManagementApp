using Crm.Tenant.Service.Models.Requests.Member.CreateMember;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Member.DeleteMember
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

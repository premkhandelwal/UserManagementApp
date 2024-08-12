using Crm.Tenant.Service.Models.Requests.Member.CreateMember;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Member.UpdateMember
{
    public class UpdateMemberValidationService : CreateMemberValidationService<UpdateMemberRequest>
    {
        public UpdateMemberValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Member.UpdateMember
{
    public class UpdateMemberValidationService : CreateMemberValidationService<UpdateMemberRequest>
    {
        public UpdateMemberValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

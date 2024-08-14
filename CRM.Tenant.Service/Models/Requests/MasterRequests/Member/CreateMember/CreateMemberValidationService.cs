using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember
{
    public class CreateMemberValidationService<T> : AbstractValidator<T> where T : CreateMemberRequest
    {
        public CreateMemberValidationService()
        {
            RuleFor(x => x.ClientId).NotEmpty().WithMessage("Client field is required.");
            RuleFor(x => x.MemberName).NotEmpty().WithMessage("Member name is required.");
        }
    }
}

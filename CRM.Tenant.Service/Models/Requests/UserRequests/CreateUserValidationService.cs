using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.UserRequests
{
    public class CreateUserValidationService<T> : AbstractValidator<T> where T : CreateUserRequest
    {
        public CreateUserValidationService()
        {
        }
    }
}

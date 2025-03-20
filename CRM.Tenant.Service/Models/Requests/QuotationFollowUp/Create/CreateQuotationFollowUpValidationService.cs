using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Create
{
    public class CreateQuotationFollowUpValidationService<T> : AbstractValidator<T> where T : CreateQuotationFollowUpRequest
    {
        public CreateQuotationFollowUpValidationService()
        {
        }
    }
}
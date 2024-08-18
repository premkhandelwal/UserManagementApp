using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.QuotationFollowUp
{
    public class CreateQuotationFollowUpValidationService<T> : AbstractValidator<T> where T : CreateQuotationFollowUpRequest
    {
        public CreateQuotationFollowUpValidationService()
        {
        }
    }
}
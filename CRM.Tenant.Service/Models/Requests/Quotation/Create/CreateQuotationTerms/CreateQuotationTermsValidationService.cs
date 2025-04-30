using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms
{
    public class CreateQuotationTermsValidationService<T> : AbstractValidator<T> where T : CreateQuotationTermsRequest
    {
        public CreateQuotationTermsValidationService()
        {
        }
    }
}

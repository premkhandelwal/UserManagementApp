using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms;
using FluentValidation;

public class QuotationTermsService: BaseService<CreateQuotationTermsRequest, QuotationTermsModel>
{
    public QuotationTermsService(IMapper mapper, BaseRepository<QuotationTermsModel> repository, IValidator<CreateQuotationTermsRequest> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
    {
    }
}
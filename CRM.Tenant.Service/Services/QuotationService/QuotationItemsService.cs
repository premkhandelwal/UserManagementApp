using AutoMapper;
using Crm.Api.Models.Quotation;
using Crm.Tenant.Data.Models;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;
using CRM.Tenant.Service.Services;
using FluentValidation;

public class QuotationItemsService : BaseService<CreateQuotationItemsRequest, QuotationItemModel>
{
    public QuotationItemsService(IMapper mapper, BaseRepository<QuotationItemModel> repository, IValidator<CreateQuotationItemsRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}
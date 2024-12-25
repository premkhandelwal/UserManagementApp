using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using FluentValidation;

public class ClientService : BaseService<CreateClientRequest, ClientModel>
{
    QuotationFieldsService _quotationFieldsService;
    public ClientService(IMapper mapper, BaseRepository<ClientModel> repository, IValidator<CreateClientRequest> validator, QuotationFieldsService quotationFieldsService)
        : base(mapper, repository, validator)
    {
        _quotationFieldsService = quotationFieldsService;
    }

    public async override Task<bool> HasReferences(ClientModel entity)
    {
        List<QuotationFieldsModel> quotations = await _quotationFieldsService.ReadAsync();
        return quotations.Any(q => q.QuotationCompanyId == entity.Id);
    }
}
using AutoMapper;
using Crm.Api.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;
using FluentValidation;

namespace CRM.Tenant.Service.Services.PurchaseOrderService
{
    public class PurchaseOrderTermsService : BaseService<CreatePurchaseOrderTermsRequest, PurchaseOrderTermsModel>
    {
        public PurchaseOrderTermsService(IMapper mapper, BaseRepository<PurchaseOrderTermsModel> repository, IValidator<CreatePurchaseOrderTermsRequest> validator)
            : base(mapper, repository, validator)
        {
        }
    }
}

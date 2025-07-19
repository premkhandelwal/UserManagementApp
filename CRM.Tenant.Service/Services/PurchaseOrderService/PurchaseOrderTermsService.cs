using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.PurchaseOrder;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;
using FluentValidation;

namespace CRM.Tenant.Service.Services.PurchaseOrderService
{
    public class PurchaseOrderTermsService : BaseService<CreatePurchaseOrderTermsRequest, PurchaseOrderTermsModel>
    {
        public PurchaseOrderTermsService(IMapper mapper, BaseRepository<PurchaseOrderTermsModel> repository, IValidator<CreatePurchaseOrderTermsRequest> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
        {
        }
    }
}

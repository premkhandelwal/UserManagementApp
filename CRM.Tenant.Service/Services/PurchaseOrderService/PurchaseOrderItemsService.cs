using AutoMapper;
using Crm.Api.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;
using FluentValidation;

namespace CRM.Tenant.Service.Services.PurchaseOrderService
{
    public class PurchaseOrderItemsService : BaseService<CreatePurchaseOrderItemsRequest, PurchaseOrderItemModel>
    {
        public PurchaseOrderItemsService(IMapper mapper, BaseRepository<PurchaseOrderItemModel> repository, IValidator<CreatePurchaseOrderItemsRequest> validator)
            : base(mapper, repository, validator)
        {
        }
    }
}
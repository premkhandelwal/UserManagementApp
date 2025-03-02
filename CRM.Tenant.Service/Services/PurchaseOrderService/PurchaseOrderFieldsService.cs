using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.PurchaseOrder;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields;
using FluentValidation;

namespace CRM.Tenant.Service.Services.PurchaseOrderService
{
    public class PurchaseOrderFieldsService : BaseService<CreatePurchaseOrderFieldsRequest, PurchaseOrderFieldsModel>
    {
        public PurchaseOrderFieldsService(IMapper mapper, BaseRepository<PurchaseOrderFieldsModel> repository, IValidator<CreatePurchaseOrderFieldsRequest> validator, IUnitOfWork unitOfWork)
        : base(mapper, repository, validator, unitOfWork)
        {
        }
    }
}
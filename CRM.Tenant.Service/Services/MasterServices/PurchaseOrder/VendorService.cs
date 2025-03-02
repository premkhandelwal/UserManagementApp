using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using FluentValidation;

namespace CRM.Tenant.Service.Services.MasterServices.PurchaseOrder
{
    public class VendorService : BaseService<CreateVendorRequest, VendorModel>
    {
        PurchaseOrderFieldsService _purchaseOrderFieldsService;
        public VendorService(IMapper mapper, BaseRepository<VendorModel> repository, IValidator<CreateVendorRequest> validator, PurchaseOrderFieldsService purchaseOrderFieldsService, IUnitOfWork unitOfWork)
        : base(mapper, repository, validator, unitOfWork)
        {
            _purchaseOrderFieldsService = purchaseOrderFieldsService;
        }

        public async override Task<bool> HasReferences(VendorModel entity)
        {
            return await _purchaseOrderFieldsService.ExistsAsync(p => p.PurchaseOrderVendorId == entity.Id);
        }
    }
}
using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using FluentValidation;

namespace CRM.Tenant.Service.Services.MasterServices.PurchaseOrder
{
    public class VendorMemberService : BaseService<CreateVendorMemberRequest, VendorMemberModel>
    {
        PurchaseOrderFieldsService _purchaseOrderFieldsService;
        public VendorMemberService(IMapper mapper, BaseRepository<VendorMemberModel> repository, IValidator<CreateVendorMemberRequest> validator, PurchaseOrderFieldsService purchaseOrderFieldsService, IUnitOfWork unitOfWork)
            : base(mapper, repository, validator, unitOfWork)
        {
            _purchaseOrderFieldsService = purchaseOrderFieldsService;
        }

        public async override Task<bool> HasReferences(VendorMemberModel entity)
        {
            return await _purchaseOrderFieldsService.ExistsAsync(p => p.PurchaseOrderAttentionId == entity.Id);
        }
    }
}
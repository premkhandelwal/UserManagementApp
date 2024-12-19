using AutoMapper;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember;
using FluentValidation;

namespace CRM.Tenant.Service.Services.MasterServices.PurchaseOrder
{
    public class VendorMemberService : BaseService<CreateVendorMemberRequest, VendorMemberModel>
    {
        public VendorMemberService(IMapper mapper, BaseRepository<VendorMemberModel> repository, IValidator<CreateVendorMemberRequest> validator)
            : base(mapper, repository, validator)
        {
        }
    }
}
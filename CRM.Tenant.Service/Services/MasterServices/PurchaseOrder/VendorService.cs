using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;
using FluentValidation;

namespace CRM.Tenant.Service.Services.MasterServices.PurchaseOrder
{
    public class VendorService : BaseService<CreateVendorRequest, VendorModel>
    {
        public VendorService(IMapper mapper, BaseRepository<VendorModel> repository, IValidator<CreateVendorRequest> validator)
            : base(mapper, repository, validator)
        {
        }
    }
}
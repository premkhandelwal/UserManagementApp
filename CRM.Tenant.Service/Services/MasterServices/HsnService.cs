using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.CreateHsn;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Unit.CreateUnit;
using FluentValidation;

namespace CRM.Tenant.Service.Services.MasterServices
{
    public class HsnService : BaseService<CreateHsnRequest, HsnModel>
    {
        public HsnService(IMapper mapper, BaseRepository<HsnModel> repository, IValidator<CreateHsnRequest> validator)
            : base(mapper, repository, validator)
        {

        }
    }
}

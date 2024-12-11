using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Unit.CreateUnit;
using FluentValidation;

namespace CRM.Tenant.Service.Services.MasterServices
{
    public class UnitService: BaseService<CreateUnitRequest, UnitModel>
    {
        public UnitService(IMapper mapper, BaseRepository<UnitModel> repository, IValidator<CreateUnitRequest> validator) 
            : base(mapper, repository, validator)
        {

        }
    }
}

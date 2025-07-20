

using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Data;
using FluentValidation;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.CreatePartNumber;
using Crm.Tenant.Data.Models.Masters.WorkOrder;

namespace CRM.Tenant.Service.Services.MasterServices.WorkOrder
{
    public class PartNumberService : BaseService<CreatePartNumberRequest, PartNumberModel>
    {
        public PartNumberService(IMapper mapper, BaseRepository<PartNumberModel> repository, IValidator<CreatePartNumberRequest> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
        {
        }
    }
}

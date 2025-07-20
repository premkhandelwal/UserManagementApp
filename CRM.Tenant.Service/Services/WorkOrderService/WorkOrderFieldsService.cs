using AutoMapper;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Data;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;
using FluentValidation;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkFields;
using Crm.Tenant.Data.Models.WorkOrder;
using Microsoft.AspNetCore.Http;

namespace CRM.Tenant.Service.Services.WorkOrderService
{
    public class WorkOrderFieldsService : BaseService<CreateWorkOrderFieldsRequest, WorkOrderFieldsModel>
    {
        public WorkOrderFieldsService(IMapper mapper, BaseRepository<WorkOrderFieldsModel> repository, IValidator<CreateWorkOrderFieldsRequest> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, repository, validator, unitOfWork, httpContextAccessor)
        {
        }
    }
}

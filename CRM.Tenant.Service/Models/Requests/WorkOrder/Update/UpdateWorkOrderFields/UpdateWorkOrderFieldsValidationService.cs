using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkFields;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderFields
{
    public class UpdateWorkOrderFieldsValidationService : CreateWorkOrderFieldsValidationService<UpdateWorkOrderFieldsRequest>
    {
        public UpdateWorkOrderFieldsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

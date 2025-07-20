
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkFields;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Delete.DeleteWorkOrderFields
{
    public class DeleteWorkOrderFieldsValidationService : CreateWorkOrderFieldsValidationService<DeleteWorkOrderFieldsRequest>
    {
        public DeleteWorkOrderFieldsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

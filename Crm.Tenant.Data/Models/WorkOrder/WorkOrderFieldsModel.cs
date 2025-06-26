using Crm.Admin.Service.Models;
using Crm.Tenant.Data.Models.Masters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.WorkOrder
{
    public class WorkOrderFieldsModel: BaseModelClass
    {
        public string? WorkOrderId { get; set; }

        public int? WorkOrderCompanyId { get; set; }

        public string? PurchareOrderNumber { get; set; }

        public DateTime WorkOrderDate { get; set; }
        [ForeignKey(nameof(WorkOrderCompanyId))]
        public virtual ClientModel? WorkOrderCompany { get; set; }

    }
}

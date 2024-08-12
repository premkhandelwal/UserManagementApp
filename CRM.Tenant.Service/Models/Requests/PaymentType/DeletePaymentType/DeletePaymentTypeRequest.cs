using Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType;

namespace Crm.Tenant.Service.Models.Requests.PaymentType.DeletePaymentType
{
    public class DeletePaymentTypeRequest : CreatePaymentTypeRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

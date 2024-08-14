using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.CreatePaymentType;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.DeletePaymentType
{
    public class DeletePaymentTypeRequest : CreatePaymentTypeRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

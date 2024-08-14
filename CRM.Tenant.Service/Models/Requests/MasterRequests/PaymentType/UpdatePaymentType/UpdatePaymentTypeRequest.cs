using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.CreatePaymentType;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.UpdatePaymentType
{
    public class UpdatePaymentTypeRequest : CreatePaymentTypeRequest
    {
        public int? Id { get; set; }
    }
}

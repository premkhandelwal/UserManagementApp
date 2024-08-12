using Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType;

namespace Crm.Tenant.Service.Models.Requests.PaymentType.UpdatePaymentType
{
    public class UpdatePaymentTypeRequest : CreatePaymentTypeRequest
    {
        public int? Id { get; set; }
    }
}

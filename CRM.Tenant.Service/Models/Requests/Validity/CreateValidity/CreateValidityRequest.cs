namespace Crm.Tenant.Service.Models.Requests.Validity.CreateValidity
{
    public class CreateValidityRequest
    {
        public string? Validity { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

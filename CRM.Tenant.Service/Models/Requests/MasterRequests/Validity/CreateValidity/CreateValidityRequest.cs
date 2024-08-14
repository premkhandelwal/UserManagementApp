namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity
{
    public class CreateValidityRequest
    {
        public string? Validity { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

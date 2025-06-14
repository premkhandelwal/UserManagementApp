namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.CreatePartNumber
{
    public class CreatePartNumberRequest
    {
        public string? PartName { get; set; }
        public string? Description { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

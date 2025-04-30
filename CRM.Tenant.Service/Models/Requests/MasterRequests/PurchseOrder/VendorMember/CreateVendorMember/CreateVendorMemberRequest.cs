namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember
{
    public class CreateVendorMemberRequest
    {
        public int? VendorId { get; set; }
        public string? MemberName { get; set; }
        public string? Designation { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public bool IsWhatsApp { get; set; }
        public string? SkypeId { get; set; }
        public string? Telephone { get; set; }
        public bool IsMainSeller { get; set; }
        public string? PMOC { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

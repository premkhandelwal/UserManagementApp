namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember
{
    public class CreateMemberRequest
    {
        public int? ClientId { get; set; }
        public string? MemberName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public bool? IsWhatsApp { get; set; }
        public string? SkypeId { get; set; }
        public string? Telephone { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

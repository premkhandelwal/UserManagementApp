using Crm.Tenant.Service.Models.Requests.Member.CreateMember;

namespace Crm.Tenant.Service.Models.Requests.Member.UpdateMember
{
    public class UpdateMemberRequest : CreateMemberRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

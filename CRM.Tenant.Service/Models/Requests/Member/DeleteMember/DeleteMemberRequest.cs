using Crm.Tenant.Service.Models.Requests.Member.CreateMember;

namespace Crm.Tenant.Service.Models.Requests.Member.DeleteMember
{
    public class DeleteMemberRequest : CreateMemberRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

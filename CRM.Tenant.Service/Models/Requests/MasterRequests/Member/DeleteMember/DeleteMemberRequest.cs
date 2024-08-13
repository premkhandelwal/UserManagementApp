using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Member.DeleteMember
{
    public class DeleteMemberRequest : CreateMemberRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

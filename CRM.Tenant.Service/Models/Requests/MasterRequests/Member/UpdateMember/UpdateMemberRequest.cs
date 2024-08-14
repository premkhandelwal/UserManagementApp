using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Member.UpdateMember
{
    public class UpdateMemberRequest : CreateMemberRequest
    {
        public int? Id { get; set; }
    }
}

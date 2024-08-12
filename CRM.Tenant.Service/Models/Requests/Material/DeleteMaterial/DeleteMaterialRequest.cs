using Crm.Tenant.Service.Models.Requests.Material.CreateMaterial;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Material.DeleteMaterial
{
    public class DeleteMaterialRequest : CreateMaterialRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

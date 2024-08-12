using Crm.Tenant.Service.Models.Requests.Material.CreateMaterial;

namespace Crm.Tenant.Service.Models.Requests.Material.UpdateMaterial
{
    public class UpdateMaterialRequest : CreateMaterialRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

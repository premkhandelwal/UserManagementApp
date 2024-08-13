using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Material.UpdateMaterial
{
    public class UpdateMaterialRequest : CreateMaterialRequest
    {
        public int? Id { get; set; }
    }
}

using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Material.DeleteMaterial
{
    public class DeleteMaterialRequest : CreateMaterialRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

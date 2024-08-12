namespace Crm.Tenant.Service.Models.Requests.Material.CreateMaterial
{
    public class CreateMaterialRequest
    {
        public string? MaterialName { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

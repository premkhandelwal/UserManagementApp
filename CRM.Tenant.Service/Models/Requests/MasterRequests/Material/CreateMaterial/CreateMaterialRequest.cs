namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial
{
    public class CreateMaterialRequest
    {
        public string? MaterialName { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

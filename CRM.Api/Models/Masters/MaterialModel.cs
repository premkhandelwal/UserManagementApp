namespace CRM.Api.Models.Masters
{
    public class MaterialModel
    {
        public string? Id { get; set; }
        public string? MaterialName { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

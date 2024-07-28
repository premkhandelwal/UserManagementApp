namespace CRM.Api.Models.Masters
{
    public class ProductModel
    {
        public string? Id { get; set; }
        public string? ProductName { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

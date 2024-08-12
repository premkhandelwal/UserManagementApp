namespace Crm.Tenant.Service.Models.Requests.Product.CreateProduct
{
    public class CreateProductRequest
    {
        public string? ProductName { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

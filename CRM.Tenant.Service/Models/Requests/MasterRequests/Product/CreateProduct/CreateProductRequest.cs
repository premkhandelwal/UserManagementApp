namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct
{
    public class CreateProductRequest
    {
        public string? ProductName { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

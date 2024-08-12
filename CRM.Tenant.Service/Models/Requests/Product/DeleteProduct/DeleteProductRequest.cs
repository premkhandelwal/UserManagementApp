using Crm.Tenant.Service.Models.Requests.Product.CreateProduct;

namespace Crm.Tenant.Service.Models.Requests.Product.DeleteProduct
{
    public class DeleteProductRequest : CreateProductRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

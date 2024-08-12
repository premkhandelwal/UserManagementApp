using Crm.Tenant.Service.Models.Requests.Product.CreateProduct;

namespace Crm.Tenant.Service.Models.Requests.Product.UpdateProduct
{
    public class UpdateProductRequest : CreateProductRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

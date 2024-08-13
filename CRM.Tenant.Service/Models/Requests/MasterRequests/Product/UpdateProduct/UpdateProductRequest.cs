using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Product.UpdateProduct
{
    public class UpdateProductRequest : CreateProductRequest
    {
        public int? Id { get; set; }
    }
}

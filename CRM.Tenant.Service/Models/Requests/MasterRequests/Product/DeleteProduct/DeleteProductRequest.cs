using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Product.DeleteProduct
{
    public class DeleteProductRequest : CreateProductRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

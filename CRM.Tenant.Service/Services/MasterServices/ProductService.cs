using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.Product.CreateProduct;
using FluentValidation;

public class ProductService : BaseService<CreateProductRequest, ProductModel>
{
    public ProductService(IMapper mapper, BaseRepository<ProductModel> repository, IValidator<CreateProductRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}
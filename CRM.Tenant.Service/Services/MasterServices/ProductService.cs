using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct;
using FluentValidation;

public class ProductService : BaseService<CreateProductRequest, ProductModel>
{
    public ProductService(IMapper mapper, BaseRepository<ProductModel> repository, IValidator<CreateProductRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}
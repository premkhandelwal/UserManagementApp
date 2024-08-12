using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType;
using FluentValidation;

public class PaymentTypeService : BaseService<CreatePaymentTypeRequest, PaymentTypeModel>
{
    public PaymentTypeService(IMapper mapper, BaseRepository<PaymentTypeModel> repository, IValidator<CreatePaymentTypeRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}
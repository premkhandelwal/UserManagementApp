﻿using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;
using FluentValidation;

public class QuotationFieldsService : BaseService<CreateQuotationFieldsRequest, QuotationFieldsModel>
{
    public QuotationFieldsService(IMapper mapper, BaseRepository<QuotationFieldsModel> repository, IValidator<CreateQuotationFieldsRequest> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
    {
    }
}
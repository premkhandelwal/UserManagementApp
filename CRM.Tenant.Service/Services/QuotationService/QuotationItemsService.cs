﻿using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;
using FluentValidation;

public class QuotationItemsService : BaseService<CreateQuotationItemsRequest, QuotationItemModel>
{
    public QuotationItemsService(IMapper mapper, BaseRepository<QuotationItemModel> repository, IValidator<CreateQuotationItemsRequest> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
    {
    }
}
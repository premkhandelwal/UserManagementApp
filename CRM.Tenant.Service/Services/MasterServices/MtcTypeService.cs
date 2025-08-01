﻿using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Services.QuotationService;
using FluentValidation;
using Microsoft.AspNetCore.Http;

public class MtcTypeService : BaseService<CreateMtcTypeRequest, MtcTypeModel>
{
    QuotationTermsService _quotationTermsService;
    PurchaseOrderTermsService _purchaseOrderTermsService;
    public MtcTypeService(IMapper mapper, BaseRepository<MtcTypeModel> repository, IValidator<CreateMtcTypeRequest> validator, QuotationTermsService quotationService, PurchaseOrderTermsService purchaseOrderTermsService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
    {
        _quotationTermsService = quotationService;
        _purchaseOrderTermsService = purchaseOrderTermsService;
    }

    public async override Task<bool> HasReferences(MtcTypeModel entity)
    {
        if (await _quotationTermsService.ExistsAsync(q => q.MtcTypeId == entity.Id))
        {
            return true;
        }
        return await _purchaseOrderTermsService.ExistsAsync(p => p.MtcTypeId == entity.Id);
    }
}
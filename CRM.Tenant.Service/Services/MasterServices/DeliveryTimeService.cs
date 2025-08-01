﻿using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Services.QuotationService;
using FluentValidation;

public class DeliveryTimeService : BaseService<CreateDeliveryTimeRequest, DeliveryTimeModel>
{
    QuotationTermsService _quotationTermsService;
    PurchaseOrderTermsService _purchaseOrderTermsService;
    public DeliveryTimeService(IMapper mapper, BaseRepository<DeliveryTimeModel> repository, IValidator<CreateDeliveryTimeRequest> validator, QuotationTermsService quotationService, PurchaseOrderTermsService purchaseOrderTermsService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
    {
        _quotationTermsService = quotationService;
        _purchaseOrderTermsService = purchaseOrderTermsService;
    }

    public async override Task<bool> HasReferences(DeliveryTimeModel entity)
    {
        return await _quotationTermsService.ExistsAsync(q => q.DeliveryTimeId == entity.Id);
    }
}
﻿using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial;
using FluentValidation;

public class MaterialService : BaseService<CreateMaterialRequest, MaterialModel>
{
    public MaterialService(IMapper mapper, BaseRepository<MaterialModel> repository, IValidator<CreateMaterialRequest> validator, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
    {
    }
}
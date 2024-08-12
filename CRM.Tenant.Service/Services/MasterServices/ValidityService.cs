﻿using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.Validity.CreateValidity;
using FluentValidation;

public class ValidityService : BaseService<CreateValidityRequest, ValidityModel>
{
    public ValidityService(IMapper mapper, BaseRepository<ValidityModel> repository, IValidator<CreateValidityRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}
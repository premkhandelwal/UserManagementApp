﻿using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using FluentValidation;

public class ClientService : BaseService<CreateClientRequest, ClientModel>
{
    public ClientService(IMapper mapper, BaseRepository<ClientModel> repository, IValidator<CreateClientRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}
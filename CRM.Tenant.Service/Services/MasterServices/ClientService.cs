using Crm.Tenant.Data.Repositories;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Service.Services.Models.Requests.Clients;
using System;

namespace CRM.Tenant.Service.Services.MasterServices
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;
        private readonly ClientValidationService _clientValidationService;
        private readonly IMapper _mapper;

        public ClientService(ClientRepository clientRepository, ClientValidationService clientValidationService, IMapper mapper) 
        {
            _clientRepository = clientRepository;
            _clientValidationService = clientValidationService;
            _mapper = mapper;
        }
        public async Task<ClientModel?> CreateClient(CreateClientRequest client)
        {
            var validationResult = _clientValidationService.Validate(client);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            ClientModel mappedClientModel = _mapper.Map<ClientModel>(client);
            mappedClientModel.IsDeleted = false;
            mappedClientModel.AddedOn = DateTime.Now;
            ClientModel result = await _clientRepository.AddAsync(mappedClientModel);
            return result;
        }
    }
}

using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tenant.Service.Services.Profiles
{
    internal class Mappings : Profile
    {
        public Mappings()
        {
            //Vms are coming in from the API, ViewModel are the local entities in Blazor
            CreateMap<ClientModel, CreateClientRequest> ().ReverseMap();

        }
    }
}

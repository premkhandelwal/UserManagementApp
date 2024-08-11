using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using CRM.Data.Models.Masters;
using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.Clients.DeleteClient;
using CRM.Tenant.Service.Models.Requests.Clients.UpdateClient;
using CRM.Tenant.Service.Models.Requests.Countries.CreateCountry;
using CRM.Tenant.Service.Models.Requests.Countries.DeleteCountry;
using CRM.Tenant.Service.Models.Requests.Countries.UpdateCountry;
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
            CreateMap<ClientModel, CreateClientRequest> ().ReverseMap();
            CreateMap<ClientModel, UpdateClientRequest>().ReverseMap();
            CreateMap<ClientModel, DeleteClientRequest>().ReverseMap();

            CreateMap<CountryModel, CreateCountryRequest>().ReverseMap();
            CreateMap<CountryModel, UpdateCountryRequest>().ReverseMap();
            CreateMap<CountryModel, DeleteCountryRequest>().ReverseMap();


        }
    }
}

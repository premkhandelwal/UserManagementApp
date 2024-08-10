using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Tenant.Service.Services.Models.Requests.Clients
{
    public class ClientValidationService : AbstractValidator<CreateClientRequest>
    {
        public ClientValidationService()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Client name is required.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country name is required.");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Region name is required.");
            RuleFor(x => x.Website).NotEmpty().WithMessage("Website name is required.");
        }
    }

}

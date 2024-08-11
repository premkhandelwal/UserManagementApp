using CRM.Data.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tenant.Service.Models.Requests.Clients.CreateClient
{
    public class CreateClientRequest
    {
        public string? CompanyName { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Website { get; set; }
        public DateTime AddedOn { get; set; }
    }
}

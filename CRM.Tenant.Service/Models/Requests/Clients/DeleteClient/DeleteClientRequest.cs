using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tenant.Service.Models.Requests.Clients.DeleteClient
{
    public class DeleteClientRequest: CreateClientRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

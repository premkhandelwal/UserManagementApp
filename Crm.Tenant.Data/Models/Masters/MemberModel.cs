﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Crm.Tenant.Data.Models.Masters;

namespace CRM.Data.Models.Masters
{
    public class MemberModel: BaseModelClass
    {
        public int? ClientId { get; set; }   
        public string? MemberName { get; set; }
        public string? Email { get; set; } 
        public string? Mobile { get; set; } 
        public bool? IsWhatsApp {  get; set; }
        public string? SkypeId { get; set; } 
        public string? Telephone { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual ClientModel? Client { get; set; }

    }
}

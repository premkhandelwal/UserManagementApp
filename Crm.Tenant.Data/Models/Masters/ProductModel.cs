﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Crm.Tenant.Data.Models.Masters;

namespace Crm.Tenant.Data.Models.Masters
{
    public class ProductModel: BaseModelClass
    {
        public string? ProductName { get; set; }
    }
}
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crm.Tenant.Data.Models.Masters
{
    public class DeliveryTimeModel: BaseModelClass
    {
        public string? DeliveryTime { get; set; }
    }
}

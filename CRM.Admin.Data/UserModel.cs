﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Admin.Data
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;

        public string Role { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public CrmIdentityUser User { get; set; } = null!;

    }
}

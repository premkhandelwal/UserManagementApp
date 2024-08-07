﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Admin.Service.Models
{
    public class TokenResponse<T>: IApiResponse<T>
    {
        public string? AuthToken { get; set; }

        public string? RefreshToken { get; set; }
    }
}

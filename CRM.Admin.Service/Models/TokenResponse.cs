﻿namespace Crm.Admin.Service.Models
{
    public class TokenResponse<T>: IApiResponse<T>
    {
        public string? AuthToken { get; set; }

        public string? RefreshToken { get; set; }
    }
}

using System;
namespace Crm.Admin.Service.Models
{
    public class IApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Response { get; set; }
        public int StatusCode { get; set; }
    }
}

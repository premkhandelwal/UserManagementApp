using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Admin.Service.Models
{
    public class IApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Response { get; set; }
        public int StatusCode { get; set; }
    }
}

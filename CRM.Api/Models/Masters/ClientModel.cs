using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApp.Models.Masters
{
    public class ClientModel
    {
        public string? Id { get; set; }
        public string? CompanyName { get; set; } 
        public string? Country { get; set; } 
        public string? Region { get; set; } 
        public string? Website { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

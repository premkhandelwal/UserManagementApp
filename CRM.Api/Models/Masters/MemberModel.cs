using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM.Admin.Data;

namespace CRM.Api.Models.Masters
{
    public class MemberModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId { get; set; }   
        public string? MemberName { get; set; }
        public string? Email { get; set; } 
        public string? Mobile { get; set; } 
        public bool? IsWhatsApp {  get; set; }
        public string? SkypeId { get; set; } 
        public string? Telephone { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey(nameof(ClientId))]
        public virtual ClientModel? Client { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Data.Models.Masters
{
    public class CountryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? CountryName { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Data.Models.Masters
{
    public class CurrencyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencyRate { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

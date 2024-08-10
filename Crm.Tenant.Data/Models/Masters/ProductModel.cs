using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Data.Models.Masters
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? ProductName { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

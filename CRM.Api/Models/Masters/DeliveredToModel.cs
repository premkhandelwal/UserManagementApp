using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Api.Models.Masters
{
    public class DeliveredToModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? DeliveryName { get; set; }
        public int TransportModeId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? AddedOn { get; set; }

        [ForeignKey(nameof(TransportModeId))]
        public virtual TransportModeModel? TransportMode { get; set; }
    }

}

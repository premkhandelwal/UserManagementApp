using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApp.Models.Masters
{
    public class DeliveredToModel
    {
        public string? Id { get; set; }
        public string? DeliveryName { get; set; }
        public string? TransportModeId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? AddedOn { get; set; }

        [ForeignKey(nameof(TransportModeId))]
        public virtual TransportModeModel? TransportMode { get; set; }
    }

}

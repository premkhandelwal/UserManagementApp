namespace CRM.Api.Models.Masters
{
    public class TransportModeModel
    {
        public string? Id { get; set; }
        public string? TransportMode { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

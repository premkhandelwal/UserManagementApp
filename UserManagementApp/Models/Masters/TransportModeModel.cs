namespace UserManagementApp.Models.Masters
{
    public class TransportModeModel
    {
        public string? Id { get; set; }
        public string? TransportModeName { get; set; }
        public DateTime AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

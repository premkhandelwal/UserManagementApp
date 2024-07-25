namespace UserManagementApp.Models.Masters
{
    public class DeliveryTimeModel
    {
        public string? Id { get; set; }
        public string? DeliveryTime { get; set; }
        public DateTime AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

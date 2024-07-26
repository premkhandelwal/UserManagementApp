namespace UserManagementApp.Models.Masters
{
    public class PaymentTypeModel
    {
        public string? Id { get; set; }
        public string? PaymentType { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

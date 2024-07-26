namespace UserManagementApp.Models.Masters
{
    public class QuotationCloseReasonModel
    {
        public string? Id { get; set; }
        public string? QuotationCloseReason { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

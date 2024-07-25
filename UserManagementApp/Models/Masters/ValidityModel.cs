namespace UserManagementApp.Models.Masters
{
    public class ValidityModel
    {
        public string? Id { get; set; }
        public string? Validity { get; set; }
        public DateTime AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

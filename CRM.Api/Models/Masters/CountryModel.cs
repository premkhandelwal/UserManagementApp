namespace UserManagementApp.Models.Masters
{
    public class CountryModel
    {
        public string? Id { get; set; }
        public string? CountryName { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

namespace UserManagementApp.Models.Masters
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string ClientId { get; set; } = "";
        public string MemberName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Mobile { get; set; } = "";
        public bool IsWhatsApp {  get; set; } = false;
        public string SkypeId { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string Action { get; set; } = "";
    }
}

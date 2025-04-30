namespace CRM.Admin.Data.Models
{
    public class SmtpConfig
    {
        public string? Server { get; set; }
        public int Port { get; set; }
        public string? SenderEmail { get; set; }
        public string? SenderPassword { get; set; }
        public bool UseSsl { get; set; }

    }
}

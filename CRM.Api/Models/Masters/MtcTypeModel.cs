namespace CRM.Api.Models.Masters
{
    public class MtcTypeModel
    {
        public string? Id { get; set; }
        public string? MtcType { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

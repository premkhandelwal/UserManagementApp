namespace Crm.Tenant.Data.Models.Masters.PurchaseOrder
{
    public class VendorModel: BaseModelClass
    {
        public string? VendorName {  get; set; }

        public string? Address { get; set; }    

        public string? GstNo {  get; set; }

        public string? ContactNo { get; set; }
    }
}

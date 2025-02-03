namespace Crm.Tenant.Data.Models.Masters.PurchaseOrder
{
    public class VendorModel: BaseModelClass
    {
        public string? VendorName {  get; set; }

        public string? Address { get; set; }    

        public string? GstNo {  get; set; }

        public string? ContactNo { get; set; }

        public string? BankName { get; set; }

        public string? BankAccountNo { get; set;}

        public string? BankIfscCode { get; set; }

        public string? BankBranchName { get; set; }

    }
}

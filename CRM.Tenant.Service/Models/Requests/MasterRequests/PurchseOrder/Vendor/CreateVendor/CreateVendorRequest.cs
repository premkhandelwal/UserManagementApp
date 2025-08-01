﻿namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor
{
    public class CreateVendorRequest
    {
        public string? VendorName { get; set; }
        public string? Address { get; set; }
        public string? GstNo { get; set; }
        public string? ContactNo {  get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankIfscCode { get; set; }
        public string? BankBranchName { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

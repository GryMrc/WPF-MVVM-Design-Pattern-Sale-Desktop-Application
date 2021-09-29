using OverPay.Model.Contact;
using OverPay.Model.Tax;
using OverPay.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OverPay.Model.Customer
{
    public class Customer:PropertyValidateModel
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public int MerchantId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
        public int? SegmentId { get; set; }
        public bool IsActive { get; set; }
        public string TaxNumber { get; set; }
        public int? TaxOfficeId { get; set; }
        public string InvoiceTitle { get; set; }
        public string EInvoiceType { get; set; }
        public string EInvoiceAddress { get; set; }
        public int? Reserved01 { get; set; }
        public decimal? Reserved02 { get; set; }
        public string Reserved03 { get; set; }
        public string Reserved04 { get; set; }
        public DateTime? Reserved05 { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string InvoicePhone { get; set; }
        public string InvoiceEMail { get; set; }
        public TaxOffice TaxOffice { get; set; }
        public Address InvoiceAddress { get; set; } = new Address();
    }
}

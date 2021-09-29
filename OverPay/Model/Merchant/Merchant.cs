using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Merchant
{
   public class Merchant
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public string MerchantName { get; set; }
        public int TypeId { get; set; }
        public bool IsActive { get; set; }
        public string TaxNumber { get; set; }
        public int? TaxOfficeId { get; set; }
        public string InvoiceTitle { get; set; }
        public bool BasicTax { get; set; }
        public int? DefaultAdminGroupId { get; set; }
        public int? DefaultUserGroupId { get; set; }
        public int? Reserved01 { get; set; }
        public decimal? Reserved02 { get; set; }
        public string Reserved03 { get; set; }
        public string Reserved04 { get; set; }
        public DateTime? Reserved05 { get; set; }
        public int TaxPayerTypeId { get; set; }
        public string MersisNo { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public long? MailLogoId { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerGender { get; set; }
        public string ManagerEMail { get; set; }
        public string ManagerPhone { get; set; }
        public int? PreferredLanguageId { get; set; }
        public bool SendNotification { get; set; }
        public string InvoiceEMail { get; set; }
        public string InvoicePhone { get; set; }
        public int InvoiceAddressId { get; set; }
     
    }
}

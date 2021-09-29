using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverPay.Model.Customer;

namespace OverPay.Model.Sale
{
    public class Sale
    {
        public long Id { get; set; }
        public int? EventId { get; set; }
        public int OrganizationId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public int CreateChannelId { get; set; }
        public int CreateBranchId { get; set; }
        public int CreateScreenId { get; set; }
        public int MerchantId { get; set; }
        public OverPay.Model.Merchant.Merchant Merchant { get; set; }
        public int ApplicationId { get; set; } = 45;
        
        public int TypeId { get; set; }
       
        public int StatusId { get; set; }
       
        public DateTime SaleDate { get; set; }
        
        public int? CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? TotalVATAmount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string CancelReason { get; set; }
        public DateTime? CancelDate { get; set; }
        public string Reserved01 { get; set; }
        public string Reserved02 { get; set; }
        public string Reserved03 { get; set; }
        public long? RelatedSaleId { get; set; }
        public Sale RelatedSale { get; set; }
        public long? RawDocumentId { get; set; }
       
        public long? SignedDocumentId { get; set; }
        
        public bool MultiPayment { get; set; }
        public bool MultiDocument { get; set; }
        public long? TransactionReportId { get; set; }
        public string TerminalKey { get; set; } = "WPF53fe3ecb107693e530d7d80719ab6aad98a5735971c5921a0c50d73ac6f872f321a22af272b0ae8b790b0eb9373b930b69c2c82e5ce21343fb192e3f0adf2";
        public string InqueryHash { get; set; }
        public string OrderNo { get; set; }
        public string GMUVersion { get; set; }
        public string Hash { get; set; }
        public string RandomNumber { get; set; }
        public string SaleNumber { get; set; }

        public List<SaleItem> AddedSaleItems { get; set; } = new List<SaleItem>();
        public IEnumerable<SaleItem> RemovedSaleItems { get; set; }
        public List<OverPay.Model.Payment.Payment> AddedPayments { get; set; } = new List<OverPay.Model.Payment.Payment>();
        public List<OverPay.Model.FinancialDocument.FinancialDocumentType> FinancialDocumentType { get; set; }
        public string NotificationPhone { get; set; }
        public string NotificationEMail { get; set; }
        public string InvoiceNo { get; set; }
        public string DocumentType { get; set; }
        public string FinancialDocumentNo { get; set; }
        public bool SendPhoneNotification { get; set; }
        public bool SendEMailNotification { get; set; }
        public IEnumerable<SaleItem> UblSaleItems { get; set; }
        public bool IsHasGenericProduct { get; set; }
        public bool IsAnynomousCustomer { get; set; }
        public bool IsOffline { get; set; }
        public bool FromExternalSource { get; set; }
        public SaleApplication Application { get; set; }
        public int TerminalId { get; set; }
        public OverPay.Model.Terminal.Terminal Terminal { get; set; }
        public IEnumerable<Model.FinancialDocument.FinancialDocument> FinancialDocuments { get; set; }
    }
}

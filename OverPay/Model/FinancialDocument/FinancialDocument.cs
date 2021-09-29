using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.FinancialDocument
{
    public class FinancialDocument
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int? EventId { get; set; }
        public int? PrivilegeId { get; set; }
        public int? PrivilegeFlags { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public int CreateChannelId { get; set; }
        public int CreateBranchId { get; set; }
        public int CreateScreenId { get; set; }
        public int TypeId { get; set; }
        public FinancialDocumentType Type { get; set; }
        public int StatusId { get; set; }
        public long SaleId { get; set; }
        public OverPay.Model.Sale.Sale Sale { get; set; }
        public int IntegratorId { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? ResponseTime { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocumentNo { get; set; }
        public int RequestCount { get; set; }
        public string IntegratorResponse { get; set; }
        public long? ReceiptId { get; set; }
        public DateTime? ProcessingTime { get; set; }
        public string NotificationPhone { get; set; }
        public string NotificationEMail { get; set; }
        public string InvoiceNo { get; set; }
        public decimal DocumentAmount { get; set; }
        public long? SaleItemId { get; set; }
        public OverPay.Model.Sale.SaleItem SaleItem { get; set; }
        public DateTime? CancelDate { get; set; }
        public string InquiryLink { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public string TypeName { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

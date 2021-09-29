using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Sale
{
    public class SaleItem
    {
        public long Id { get; set; }
        public int? EventId { get; set; }
        public int OrganizationId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public int CreateChannelId { get; set; }
        public int CreateBranchId { get; set; }
        public int CreateScreenId { get; set; }
        public long SaleId { get; set; }
        public Sale Sale { get; set; }
        public int StatusId { get; set; }
        //public ItemStatus Status { get; set; }
        public string Name { get; set; }
        public int ItemNo { get; set; }
        public DateTime InsertTime { get; set; }
        public int? ProductId { get; set; }
        public OverPay.Model.Product.Product Product { get; set; }
        public int? UnitId { get; set; }
        public OverPay.Model.Product.ProductUnit Unit { get; set; }
        public decimal ItemQuantity { get; set; }
        public decimal UnitPriceAmount { get; set; }
        public decimal GrossPriceAmount { get; set; }
        public decimal? TotalPriceAmount { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? VATRate { get; set; }
        public string Barcode { get; set; }
        public string QRCode { get; set; }
        public string StockReference { get; set; }
        public string CancelReason { get; set; }
        public DateTime? CancelDate { get; set; }
        public string ReservedText { get; set; }
        public decimal? UnitBaseAmount { get; set; }
        public string UnitName { get; set; }
        public int? TaxGroupId { get; set; }
        public OverPay.Model.Tax.TaxGroup TaxGroup { get; set; }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public string TicketNumber { get; set; }
        public string TicketHolderName { get; set; }
        public string TicketHolderIdNo { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}


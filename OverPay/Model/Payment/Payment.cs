using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Payment
{
    public class Payment
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
        public  OverPay.Model.Sale.Sale Sale { get; set; }
        public int StatusId { get; set; }
       
        public int MerchantId { get; set; }
        public OverPay.Model.Merchant.Merchant Merchant { get; set; }
        public int PositionNo { get; set; }
        public decimal PaymentAmount { get; set; }
        public int? InstallmentCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string ReservedText { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime? CancelDate { get; set; }
        public long? RelatedPaymentId { get; set; }
        public Payment RelatedPayment { get; set; }
        public string DirectionType { get; set; }
        public int PaymentMediatorId { get; set; }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public CashPayment CashPayment { get; set; }
        public string RequestScheme { get; set; }
        public string RequestHost { get; set; }
        public string RequestOrigin { get; set; }
       
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

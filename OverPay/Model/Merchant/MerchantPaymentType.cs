using OverPay.Model.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Merchant
{
    public class MerchantPaymentType
    {
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public int CreateChannelId { get; set; }
        public int CreateBranchId { get; set; }
        public int CreateScreenId { get; set; }
        public bool IsActive { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? ChargeRate { get; set; }
    }
}

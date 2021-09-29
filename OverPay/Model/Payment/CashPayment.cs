using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Payment
{
    public class CashPayment
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
        public long PaymentId { get; set; }
        public Payment Payment { get; set; }
        public long SaleId { get; set; }
        public OverPay.Model.Sale.Sale Sale { get; set; }
        public decimal GivenAmount { get; set; }
        public decimal ChangeAmount { get; set; }
    }
}

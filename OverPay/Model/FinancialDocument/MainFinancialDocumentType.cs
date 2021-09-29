using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OverPay.Model.FinancialDocument
{
   public class MainFinancialDocumentType
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string Description { get; set; }
        public string PaymentDirection { get; set; }
        public string PayableAmount { get; set; }
        public bool IsPerSaleItem { get; set; }
        public bool IsInformationSlip { get; set; }
        public int Id { get; set; }
    }
}

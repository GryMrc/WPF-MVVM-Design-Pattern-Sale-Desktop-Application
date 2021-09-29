using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverPay.Model.Customer
{
   public class CustomerInformation
    {
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public string TaxNumber { get; set; }
        public string InvoiceTitle { get; set; }
        public string InvoiceEMail { get; set; }
        public string InvoicePhone { get; set; }
        public string InvoiceAddress { get; set; }
    }
}

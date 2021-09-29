using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Product
{
   public class ProductUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasDecimal { get; set; }
        public string Description { get; set; }
        public string TUIKCode { get; set; }
        public string UBLCode { get; set; }
        public string UBLName { get; set; }

    }
}

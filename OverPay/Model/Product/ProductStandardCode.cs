using OverPay.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OverPay.Model.Product
{
    public class ProductStandardCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TUIKCode { get; set; }
        public string Description { get; set; }

    }
}

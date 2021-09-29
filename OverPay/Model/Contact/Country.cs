using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Contact
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InternationalCode { get; set; }
        public bool UseCityList { get; set; }
        public string PhoneCode { get; set; }
        public string Description { get; set; }
    }
}

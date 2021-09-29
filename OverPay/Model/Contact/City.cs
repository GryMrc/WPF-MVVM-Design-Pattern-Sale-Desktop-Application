using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Contact
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        public string PlateCode { get; set; }
        public string AreaCode { get; set; }
        public string Description { get; set; }
    }
}

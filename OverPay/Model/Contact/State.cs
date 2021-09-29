using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Contact
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string ShortName { get; set; }
        public string Note { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Contact
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Note { get; set; }
    }
}

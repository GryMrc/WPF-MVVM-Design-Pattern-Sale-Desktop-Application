using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Contact
{
    public class Address
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public int OrganizationId { get; set; }
        public int ContactId { get; set; }
        public int SubContactTypeId { get; set; }
        public string Type { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; } = new Country();
        public int? StateId { get; set; }
        public State State { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; } = new City();
        public int? DistrictId { get; set; }
        public District District { get; set; } = new District();
        public int? NeighborhoodId { get; set; }
        public string AddressText { get; set; }
    }
}

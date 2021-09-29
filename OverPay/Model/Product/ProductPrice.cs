using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Product
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

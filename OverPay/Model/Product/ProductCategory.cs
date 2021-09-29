using OverPay.Model.FinancialDocument;
using OverPay.Model.Tax;
using OverPay.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace OverPay.Model.Product
{
    public class ProductCategory : PropertyValidateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Alan Boş Bırakılamaz!")]
        public string Name { get; set; }

        public int OrganizationId { get; set; }
        public int MerchantId { get; set; }
        public int? ParentId { get; set; }
        public ProductCategory Parent { get; set; }
        public int? TaxGroupId { get; set; }
        public TaxGroup TaxGroup { get; set; }
        public string Description { get; set; }
        public long? ImageId { get; set; }
        public string ExternalReference { get; set; }
        public MainFinancialDocumentType mainDocumentType { get; set; }
        public int? MainDocumentTypeId { get; set; }
    }
}

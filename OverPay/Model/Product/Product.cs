using OverPay.Model.Tax;
using OverPay.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace OverPay.Model.Product
{
    public class Product: PropertyValidateModel, INotifyPropertyChanged
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string Name { get; set; }

        public bool Deleted { get; set; } = false;
        public int OrganizationId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public TaxGroup TaxGroup { get; set; }
        public int? TaxGroupId { get; set; }
        public int? CategoryId { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsGeneric { get; set; }
        public int StandardCodeId { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        private ProductStandardCode standardCode;
        public string Barcode { get; set; }
        public int UnitId { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public ProductUnit Unit { get; set; }
        public int MerchantId { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        private ProductPrice productPrice;
        public ProductPrice ProductPrice { get => productPrice; set { productPrice = value; onPropertyChanged("ProductPrice"); } }
        public decimal PriceAmount { get; set; }
        public ProductStandardCode StandardCode { get => standardCode; set { standardCode = value; onPropertyChanged("StandardCode"); } }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Customized
        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /*Section="ClassFooter"*/
    }
}

using OverPay.Global;
using OverPay.Services.Product;
using OverPay.Services.Tax;
using OverPay.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace OverPay.Windows.Product
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class ProductEdit : Window
    {
       private ProductService productService;
       private ProductUnitService productUnitService;
       private TaxGroupService taxGroupService;
       private ProductStandardCodeService productStandardCodeService;
       private ProductPriceService productPriceService;
       private OverPay.Model.Product.Product _editItem;
       private ObservableCollection<OverPay.Model.Product.Product> products; 
        public ProductEdit()
        {
            InitializeComponent();
            productService = new ProductService();
            productUnitService = new ProductUnitService();
            taxGroupService = new TaxGroupService();
            productStandardCodeService = new ProductStandardCodeService();
            productPriceService = new ProductPriceService();
            this.Loaded += CRUD_Loaded;
        }

        private async void CRUD_Loaded(object sender, RoutedEventArgs e)
        {
            products = (ObservableCollection<OverPay.Model.Product.Product>)ProductList.DataContext;
            _editItem = (Model.Product.Product)editItem.DataContext;
            await CallServices();
        }
        private async void CRUD_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(ProductName))
            {
                MessageBox.Show((string)Validation.GetErrors(ProductName)[0].ErrorContent);
                ProductName.Focus();
            }

           

            else if (Validation.GetHasError(ProductUnitList))
            {
                MessageBox.Show((string)Validation.GetErrors(ProductUnitList)[0].ErrorContent);
                ProductUnitList.Focus();
            }

            else if (Validation.GetHasError(StandardCodeList))
            {
                MessageBox.Show((string)Validation.GetErrors(StandardCodeList)[0].ErrorContent);
                StandardCodeList.Focus();
            }

            else if (Validation.GetHasError(Price))
            {
                MessageBox.Show((string)Validation.GetErrors(Price)[0].ErrorContent);
                Price.Focus();
            }

            else
            {
                if (CRUD_BUTTON.Content.Equals("Ekle"))
                {

                        await this.Create();
                }

                else if (CRUD_BUTTON.Content.Equals("Güncelle")) await this.Update();
                else if (CRUD_BUTTON.Content.Equals("Sil")) await this.Delete();
            }
        }

        private async Task Create()
        {

            var response = await productService.Create(_editItem);
            if (response.isSuccessed)
            {
                MessageBox.Show("Kayıt Oluşturuldu");
                this.Close();
            }

            else
            {
                MessageBox.Show(response.message);
            }

        }

        private async Task Update()
        {
            var response = await productService.Update(_editItem);
            if (response.isSuccessed)
            {
                MessageBox.Show("Kayıt Güncellendi");
                this.Close();
            }

            else
            {
                MessageBox.Show(response.message);
            }
        }

        private async Task Delete()
        {
            if (await productService.Delete(_editItem.Id))
            {
                MessageBox.Show("Kayıt Silindi");
                this.Close();
            }

            else
            {
                MessageBox.Show("Error");
            }
        }

        private async Task CallServices()
        {
            this.ProductUnitList.ItemsSource = await productUnitService.ListAll();
            this.TaxGroupList.ItemsSource = await taxGroupService.ListAll();
            this.StandardCodeList.ItemsSource = await productStandardCodeService.ListAll();
            this._editItem.ProductPrice = await productPriceService.GetProductPrice(_editItem.Id);
            this._editItem.PriceAmount = _editItem.ProductPrice != null ? _editItem.ProductPrice.Price : 0;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

using OverPay.Command;
using OverPay.Model.Enum;
using OverPay.Model.FinancialDocument;
using OverPay.Model.Tax;
using OverPay.Services.FinancialDocument;
using OverPay.Services.Product;
using OverPay.Services.Tax;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OverPay.Windows.ProductCategory
{
    /// <summary>
    /// Interaction logic for ProductCategoryEdit.xaml
    /// </summary>
    public partial class ProductCategoryEdit : Window
    {
        private ProductCategoryService productCategoryService;
        private TaxGroupService taxGroupService;
        private MainFinancialDocumentTypeService financialDocumentTypeService;
        private ObservableCollection<OverPay.Model.Product.ProductCategory> productCategories;
        private OverPay.Model.Product.ProductCategory _editItem;

        public ProductCategoryEdit()
        {
            InitializeComponent();
            productCategoryService = new ProductCategoryService();
            taxGroupService = new TaxGroupService();
            financialDocumentTypeService = new MainFinancialDocumentTypeService();
            this.Loaded += CRUD_Loaded;
        }
        private async void CRUD_Loaded(object sender, RoutedEventArgs e)
        {
            productCategories = (ObservableCollection<OverPay.Model.Product.ProductCategory>)ProductCategories.DataContext; 
            _editItem = (Model.Product.ProductCategory)editItem.DataContext;
            await this.CallServices();
        }
        private async Task CallServices()
        {
            this.TaxGroupList.ItemsSource = await taxGroupService.ListAll();
            this.DocumentTypeList.ItemsSource = await financialDocumentTypeService.ListAll();
        }

        private async Task Create()
        {
            var response = await productCategoryService.Create(_editItem);

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
            var response = await productCategoryService.Update(_editItem);

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
            if (await productCategoryService.Delete(_editItem.Id))
            {
                MessageBox.Show("Kayıt Silindi");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void btn_CRUD(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(ProductCategoryName))
            {
                MessageBox.Show((string)Validation.GetErrors(ProductCategoryName)[0].ErrorContent);
                ProductCategoryName.Focus();
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

        private async void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string query = (sender as TextBox).Text;
            if (query.Length > 2)
            {
                bool found = false;
                var data = await productCategoryService.SearchMerchantProduct(query);
                // Clear the list   
                resultStack.Children.Clear();
                // Add the result   
                foreach (var obj in data)
                {
                    if (obj.Name.ToLower().Contains(query.ToLower()))
                    {
                        addItem(obj);
                        found = true;
                    }
                }
                if (!found)
                {
                    resultStack.Children.Add(new TextBlock() { Text = "No results found." });
                }
            }
        }
        private void addItem(OverPay.Model.Product.ProductCategory productCategory)
        {
            TextBlock block = new TextBlock();
            // Add the text   
            block.Text = productCategory.Name;
            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;
            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                Parent.Text = (sender as TextBlock).Text;
                this._editItem.ParentId = productCategory.Id;
                resultStack.Children.Clear();
            };
            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Gray;
            };
            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };
            // Add to the panel   
            resultStack.Children.Add(block);
        }
    }
}

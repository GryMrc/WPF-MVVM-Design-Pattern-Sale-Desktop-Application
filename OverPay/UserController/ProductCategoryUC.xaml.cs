using OverPay.Model.Product;
using OverPay.Services.Product;
using OverPay.ViewModel;
using OverPay.Windows.ProductCategory;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OverPay.UserController
{
    /// <summary>
    /// Interaction logic for ProductCategory.xaml
    /// </summary>
    public partial class ProductCategoryUC : UserControl
    {
        bool sorting = false;

        public ProductCategoryUC()
        {
            InitializeComponent();
        }

        private async void columnHeader_Click(object sender, RoutedEventArgs e)
        {
            var columnHeader = sender as DataGridColumnHeader;
           ProductCategoryVM productCategoryVM = (ProductCategoryVM)this.DataContext; // construct'ta yapinca datacontext daha dolmadigi icin null exp. veriyor.
            sorting = !sorting;
            if (columnHeader != null && columnHeader.Content.Equals("Kategori Adı"))
            {
                if (sorting)
                {
                    productCategoryVM.sortDirection = "Name-desc";
                }
                else
                {
                    productCategoryVM.sortDirection = "Name-asc";
                }

                await productCategoryVM.BindDataAsync();
            }
        }
    }
}

using OverPay.Services.Product;
using OverPay.ViewModel;
using OverPay.Windows.Product;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace OverPay.UserController
{
    /// <summary>
    /// Interaction logic for Prodcut.xaml
    /// </summary>
    public partial class ProductUC : UserControl
    {
        bool sorting = false;

        public ProductUC()
        {
            InitializeComponent();
        }

        private async void columnHeader_Click(object sender, RoutedEventArgs e)
        {
            var columnHeader = sender as DataGridColumnHeader;
            ProductVM productVM = (ProductVM)this.DataContext; // construct'ta yapinca datacontext daha dolmadigi icin null exp. veriyor.
            sorting = !sorting;
            if (columnHeader != null && columnHeader.Content.Equals("Ürün Adı"))
            {
                if (sorting)
                {
                    productVM.sortDirection = "Name-desc";
                }
                else
                {
                    productVM.sortDirection = "Name-asc";
                }

                await productVM.BindDataAsync();
            }
        }



    }
}

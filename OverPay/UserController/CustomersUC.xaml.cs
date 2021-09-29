using OverPay.Services.Customer;
using OverPay.ViewModel;
using OverPay.Windows.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class CustomersUC : UserControl
    {
        CustomerVM customerVM;
        bool sorting = false;

        public CustomersUC()
        {
            InitializeComponent();
        }

        private async void columnHeader_Click(object sender, RoutedEventArgs e)
        {
            var columnHeader = sender as DataGridColumnHeader;
            customerVM = (CustomerVM)this.DataContext; // construct'ta yapinca datacontext daha dolmadigi icin null exp. veriyor.
            sorting = !sorting;
            if (columnHeader != null && columnHeader.Content.Equals("Müşteri İsmi"))
            {
                if (sorting)
                {
                customerVM.sortDirection = "InvoiceTitle-desc";
                }
                else
                {
                    customerVM.sortDirection = "InvoiceTitle-asc";
                }

                await customerVM.BindDataAsync();
            }
        }
    }
}

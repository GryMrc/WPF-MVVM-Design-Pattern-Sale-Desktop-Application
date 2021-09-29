using OverPay.Model.Sale;
using OverPay.Services.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for CompleteSaleUC.xaml
    /// </summary>
    public partial class CompleteSaleUC : UserControl
    {
        private readonly CustomerTypeService customerTypeService;
        public CompleteSaleUC()
        {
            InitializeComponent();
            customerTypeService = new CustomerTypeService();
            Loaded += CompleteSaleUC_Loaded;
        }

        private async void CompleteSaleUC_Loaded(object sender, RoutedEventArgs e)
        {
            Sale sale = (Sale)this.DataContext;
            if(sale.Customer == null)
            {
                this.CustomerInfo.Visibility = Visibility.Collapsed;
            }
            else
            {
                var customerType = await customerTypeService.ListAll();
                sale.Customer.CustomerType = customerType.FirstOrDefault(c => c.Id == sale.Customer.CustomerTypeId);
            }
        }
    }
}

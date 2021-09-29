
using OverPay.Global;
using OverPay.Model.Product;
using OverPay.Services.Authentication;
using OverPay.Services.Customer;
using OverPay.UserController;
using OverPay.ViewModel;
using OverPay.Windows.Login;
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
using ProductCategoryUC = OverPay.UserController.ProductCategoryUC;

namespace OverPay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuthenticationService authenticationService;

        public MainWindow()
        {
            InitializeComponent();
            authenticationService = new AuthenticationService();
            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CallContentData.AddUserController(Content_Data, new HomeUC());
        }
        private void click_uc_home(object sender, RoutedEventArgs e)
        {
            CallContentData.AddUserController(Content_Data, new HomeUC());
        }
        private async void click_uc_customer(object sender, RoutedEventArgs e)
        {
            OverPay.UserController.CustomersUC customerUc = new OverPay.UserController.CustomersUC();
            CustomerVM customerVM = new CustomerVM();
            await customerVM.BindDataAsync();
            customerUc.DataContext = customerVM;
            CallContentData.AddUserController(Content_Data, customerUc);
        }

        private async void click_uc_product(object sender, RoutedEventArgs e)
        {
            OverPay.UserController.ProductUC prodcutUC = new OverPay.UserController.ProductUC();
            ProductVM productVM = new ProductVM();
            await productVM.BindDataAsync();
            prodcutUC.DataContext = productVM;
            CallContentData.AddUserController(Content_Data, prodcutUC);
        }
        
        private async void click_uc_productCategory(object sender, RoutedEventArgs e)
        {
            ProductCategoryUC productCategory = new ProductCategoryUC();
            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            await productCategoryVM.BindDataAsync();
            productCategory.DataContext = productCategoryVM;
            CallContentData.AddUserController(Content_Data,productCategory);
        }
        private void click_uc_Sale(object sender, RoutedEventArgs e)
        {
            CallContentData.AddUserController(Content_Data, new SaleUC(Content_Data));
        }

        private void click_uc_Logout(object sender, RoutedEventArgs e)
        {
            if (authenticationService.LogOut())
            {
            Login login = new Login();
            login.Show();
            this.Close();
            }

            else
            {
                MessageBox.Show("Çıkış Yapılamadı!");
            }
        }
    }
}

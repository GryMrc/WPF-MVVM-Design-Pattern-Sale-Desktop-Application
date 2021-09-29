using System;
using System.Collections.Generic;
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
using OverPay.Global;
using OverPay.Model.Customer;
using OverPay.Model.Enum;
using OverPay.Services.Contact;
using OverPay.Services.Customer;
using OverPay.Services.Tax;

namespace OverPay.Windows.Customer
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class CustomerEdit : Window
    {
        private CustomerTypeService customerTypeService;
        private TaxOfficeService taxOfficeService;
        private CountryService countryService;
        private CityService cityService;
        private DistrictService districtService;
        private CustomerService customerService;
        private OverPay.Model.Customer.Customer customer;
      
        public CustomerEdit()
        {
            InitializeComponent();
            this.Loaded += CRUD_Loaded;
           
            customerService = new CustomerService();
            customerTypeService = new CustomerTypeService();
            taxOfficeService = new TaxOfficeService();
            countryService = new CountryService();
            cityService = new CityService();
            districtService = new DistrictService();
        }
        private async void CRUD_Loaded(object sender, RoutedEventArgs e)
        {
            customer = (Model.Customer.Customer)editItem.DataContext;
            await CallServices();
           
        }
        private async void CRUD_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(CustomerName))
            {
                MessageBox.Show((string)Validation.GetErrors(CustomerName)[0].ErrorContent);
                CustomerName.Focus();
            }

            else
            {

            if (CRUD_BUTTON.Content.Equals("Ekle")) await this.Create();
            else if (CRUD_BUTTON.Content.Equals("Güncelle")) await this.Update();
            else if (CRUD_BUTTON.Content.Equals("Sil")) await this.Delete();

            }

        }
        private async void CountryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = int.Parse(this.CountryList.SelectedValue.ToString());
            this.CityList.ItemsSource =await this.cityService.ListAll();
        }
        private async void CityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = int.Parse(this.CityList.SelectedValue.ToString());
            this.DistrictList.ItemsSource = await this.districtService.ListAll();
        }
        private async Task CallServices()
        {
            this.CustomerTypeList.ItemsSource = await customerTypeService.ListAll();
            this.TaxOfficeList.ItemsSource = await taxOfficeService.ListAll();
            this.CountryList.ItemsSource = await countryService.ListAll();
        }
        private async Task Create()
        {
            customer.InvoiceAddress.CountryId = int.Parse(this.CountryList.SelectedValue.ToString());
            customer.InvoiceAddress.CityId = int.Parse(this.CityList.SelectedValue.ToString());
            customer.InvoiceAddress.DistrictId = int.Parse(this.DistrictList.SelectedValue.ToString());
            customer.InvoiceAddress.NeighborhoodId = 2;
            customer.InvoiceAddress.Type = "L";
            customer.InvoiceAddress.AddressText = "ada";
            if (await customerService.Create(customer))
            {
                MessageBox.Show("Kayıt Eklendi");
                this.Close();
            }
            else MessageBox.Show("Error");
            
        }
        private async Task Update()
        {
            if (await customerService.Update(customer))
            {
                MessageBox.Show("Kayıt Güncellendi");
                this.Close();
            }
            else MessageBox.Show("Error");

        }
        private async Task Delete()
        {
            if (await customerService.Delete(customer.Id))
            {
                MessageBox.Show("Kayıt Silindi");
                this.Close();
            }
            else MessageBox.Show("Error");

        }
        private void CancelCustomerClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}


using OverPay.Command;
using OverPay.Global;
using OverPay.Model.Customer;
using OverPay.Model.Response;
using OverPay.Services.Customer;
using OverPay.Windows.Customer;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OverPay.ViewModel
{
    public class CustomerVM:INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private readonly CustomerService customerService;
        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;
        public string EditTitle { get; set; }
        public string ButtonColor { get; set; }
        public string ButtonContent { get; set; }
        public bool IsEnable { get; set; } = true;
        public int PageSize { get; set; } = 15;
        private int page { get; set; } = 1;
        private int totalPage;
        public string sortDirection { get; set; }
        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Customer> Customers { get => customers; set { customers = value; onPropertyChanged("Customers"); } }
        public Customer SelectedCustomer { get => selectedCustomer; set { selectedCustomer = value; onPropertyChanged("SelectedCustomer"); } }
        public int Page { get => page; set { page = value; onPropertyChanged("Page"); } }
        public int TotalPage { get => totalPage; set { totalPage = value % PageSize > 0 ? (value / PageSize) + 1 : value / PageSize; } }
       
        public CustomerVM()
        {
            customerService = new CustomerService();
            createCommand = new RelayCommand(onCreate, CanUserCreate);
            updateCommand = new RelayCommand(onUpdate, CanUserUpdate);
            deleteCommand = new RelayCommand(onDelete, CanUserDelete);
            previousPageCommand = new RelayCommand(onPrevious, CanPreviousPage);
            nextPageCommand = new RelayCommand(onNext, CanNextPage);
        }
        public async Task BindDataAsync()
        {
            JwtResponse<Customer> asb = await this.customerService.ListAll(PageSize, page, sortDirection);
            this.Customers = new ObservableCollection<Customer>(asb.Data);
            this.TotalPage = asb.Total;
        }

        private ICommand createCommand;
        private ICommand updateCommand;
        private ICommand deleteCommand;
        private ICommand previousPageCommand;
        private ICommand nextPageCommand;
        public ICommand CreateCommand
        {
            get
            {
                return createCommand;
            }
            set
            {
                if (createCommand == null)
                    return;
                createCommand = value;
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
            set
            {
                if (updateCommand == null)
                    return;
                updateCommand = value;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
            set
            {
                if (deleteCommand == null)
                    return;
                deleteCommand = value;
            }
        }
        public ICommand PreviousPageCommand
        {
            get
            {
                return previousPageCommand;
            }
            set
            {
                if (previousPageCommand == null)
                    return;
                previousPageCommand = value;
            }
        }
        public ICommand NextPageCommand
        {
            get
            {
                return nextPageCommand;
            }
            set
            {
                if (nextPageCommand == null)
                    return;
                nextPageCommand = value;
            }
        }

        private async void onCreate(object value)
        {
            this.Page = 1;
            CustomerEdit addCustomer = new CustomerEdit();
            EditScreenInitiate("Ekle", "#52BE80", true);
            SelectedCustomer = new Customer();
            SelectedCustomer.MerchantId = CurrentMerchantInformation.merchant.Id;
            addCustomer.DataContext = this;
            addCustomer.ShowDialog();
            await BindDataAsync();

        }
        private bool CanUserCreate(object value)
        {
            return true;
        }

        private async void onUpdate(object value)
        {
            SelectedCustomer = (Customer)value;
            SelectedCustomer = await customerService.GetByMasterId(SelectedCustomer.Id);
            var customerInformation = await customerService.GetByCustomerIdForSaleSummary(selectedCustomer.Id);
            fillCustomerContact(customerInformation);
            CustomerEdit updateCustomer = new CustomerEdit();
            EditScreenInitiate("Güncelle", "#52BE80", true);
            updateCustomer.DataContext = this;
            updateCustomer.ShowDialog();
            await BindDataAsync();
        }
        private bool CanUserUpdate(object value)
        {
            return true;
        }

        private async void onDelete(object value)
        {
            SelectedCustomer = (Customer)value;
            CustomerEdit deleteCustomer = new CustomerEdit();
            EditScreenInitiate("Sil", "#E74C3C", false);
            deleteCustomer.DataContext = this;
            deleteCustomer.ShowDialog();
            await BindDataAsync();
        }

        private bool CanUserDelete(object value)
        {
            return true;
        }
        private async void onPrevious(object value)
        {
            this.Page--;
            await BindDataAsync();

        }

        private bool CanPreviousPage(object value)
        {
            return this.Page > 1;
        }

        private async void onNext(object value)
        {
            this.Page++;
            await BindDataAsync();
        }

        private bool CanNextPage(object value)
        {
            return this.Page <= TotalPage - 1;
        }

        private void EditScreenInitiate(string editType, string buttonColor, bool isEnable)
        {
            EditTitle = "Müşteri " + editType;
            ButtonContent = editType;
            ButtonColor = buttonColor;
            IsEnable = isEnable;
        }

        private void fillCustomerContact(CustomerInformation customerInformation)
        {
            SelectedCustomer.InvoiceEMail = customerInformation.InvoiceEMail;
            SelectedCustomer.InvoicePhone = customerInformation.InvoicePhone;
        }
    }
}

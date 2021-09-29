using OverPay.Command;
using OverPay.Global;
using OverPay.Model.Product;
using OverPay.Model.Response;
using OverPay.Services.Product;
using OverPay.Windows.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace OverPay.ViewModel
{
    public class ProductVM : INotifyCollectionChanged, INotifyPropertyChanged
    {
        private readonly ProductService productService;
        private readonly ProductPriceService productPriceService;
        private readonly ProductStandardCodeService productStandardCodeService;
        private ObservableCollection<Product> products;
        private Product selectedProduct;
        public string EditTitle { get; set; }
        public string ButtonColor { get; set; }
        public string ButtonContent { get; set; }
        public bool IsEnable { get; set; } = true;
        public int PageSize { get; set; } = 15;
        public int total { get; set; }
        private int page = 1;
        private int totalPage;
        public string sortDirection { get; set; }
        public bool priceConverter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private ICommand deleteCommand;
        private ICommand createCommand;
        private ICommand updateCommand;
        private ICommand previousPageCommand;
        private ICommand nextPageCommand;
        private ICommand displayPriceCommand;
        

        public ProductVM()
        {
            createCommand = new RelayCommand(onCreate, CanUserCreate);
            updateCommand = new RelayCommand(onUpdate, CanUserUpdate);
            deleteCommand = new RelayCommand(onDelete, CanUserDelete);
            previousPageCommand = new RelayCommand(onPrevious, CanPreviousPage);
            nextPageCommand = new RelayCommand(onNext, CanNextPage);
            displayPriceCommand = new RelayCommand(onDisplayPrice, CanDisplayPrice);
            productService = new ProductService();
            productPriceService = new ProductPriceService();
            productStandardCodeService = new ProductStandardCodeService();
        }

        public async Task BindDataAsync()
        {
            JwtResponse<OverPay.Model.Product.Product> asb = await this.productService.ListAll(PageSize, page, sortDirection);
            this.Products = new ObservableCollection<Product>(asb.Data);
            this.TotalPage = (asb.Total);
            var standarCodeList = await productStandardCodeService.ListAll();
            foreach (var item in Products)
            {
                item.StandardCode = standarCodeList.FirstOrDefault(s => s.Id == item.StandardCodeId);
            }
        }

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

        public ICommand DisplayPriceCommand
        {
            get
            {
                return displayPriceCommand;
            }
            set
            {
                if (displayPriceCommand == null)
                    return;
                displayPriceCommand = value;
            }
        }

        public int Page { get => page; set { page = value; onPropertyChanged("Page"); } }
        public ObservableCollection<Product> Products { get => products; set { products = value; onPropertyChanged("Products"); } }

        public Product SelectedProduct { get => selectedProduct; set { selectedProduct = value; onPropertyChanged("SelectedProduct"); } }

        public int TotalPage { get => totalPage; set { totalPage = value % PageSize > 0 ? (value / PageSize) + 1 : value / PageSize; } }

        private async void onCreate(object value)
        {
            this.Page = 1;
            ProductEdit addProduct = new ProductEdit();
            EditScreenInitiate("Ekle", "#52BE80", true);
            SelectedProduct = new Product();
            SelectedProduct.MerchantId = CurrentMerchantInformation.merchant.Id;
            addProduct.DataContext = this;
            addProduct.ShowDialog();
            await BindDataAsync();
        }

        private bool CanUserCreate(object value)
        {
            return true;
        }

        private async void onUpdate(object value)
        {
            SelectedProduct = (Product)value;
            ProductEdit updateProduct = new ProductEdit();
            EditScreenInitiate("Güncelle", "#52BE80", true);
            updateProduct.BarcodeNo.IsEnabled = false;
            updateProduct.DataContext = this;
            updateProduct.ShowDialog();
            await BindDataAsync();
        }

        private bool CanUserUpdate(object value)
        {
            return true;
        }

        private async void onDelete(object value)
        {
            ProductEdit deleteProduct = new ProductEdit();
            EditScreenInitiate("Sil", "#E74C3C", false);
            SelectedProduct = (Product)value;
            deleteProduct.DataContext = this;
            deleteProduct.ShowDialog();
            await BindDataAsync();
        }

        private bool CanUserDelete(object value)
        {
            return true;
        }

        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EditScreenInitiate(string editType, string buttonColor, bool isEnable)
        {
            EditTitle = "Ürün" + editType;
            ButtonContent = editType;
            ButtonColor = buttonColor;
            IsEnable = isEnable;
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

        private async void onDisplayPrice(object value)
        {
            priceConverter = !priceConverter;

            var values = (object[])value;
            var button = (Button)values[0];
            SelectedProduct = (Product)values[1];
            var productPrice = await productPriceService.GetProductPrice(selectedProduct.Id);
            SelectedProduct.ProductPrice = productPrice;
            if (priceConverter)
            {
            button.Content = SelectedProduct.ProductPrice == null ? "0" : SelectedProduct.ProductPrice.Price;
            }
            else
            {
                button.Content = "Fiyatı Gör";
            }
        }

        private bool CanDisplayPrice(object value)
        {
            return true;
        }
    }
}


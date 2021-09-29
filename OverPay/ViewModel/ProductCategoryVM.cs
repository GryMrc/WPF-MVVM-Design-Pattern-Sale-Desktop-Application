using GalaSoft.MvvmLight;
using OverPay.Command;
using OverPay.CRUD;
using OverPay.Global;
using OverPay.Model.Product;
using OverPay.Model.Response;
using OverPay.Services.Product;
using OverPay.Validate;
using OverPay.Windows.Product;
using OverPay.Windows.ProductCategory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OverPay.ViewModel
{
    public class ProductCategoryVM : INotifyCollectionChanged, INotifyPropertyChanged
    {
        private readonly ProductCategoryService productCategoryService;
        private ObservableCollection<OverPay.Model.Product.ProductCategory> productCategories;
        private ProductCategory selectedProductCategory;
        private readonly Dictionary<string, string> errorCollection = new Dictionary<string, string>();
        public string EditTitle { get; set; }
        public string ButtonColor { get; set; }
        public string ButtonContent { get; set; }
        public bool IsEnable { get; set; } = true;
        public int total { get; set; }
        private int page { get; set; } = 1;
        private int totalPage { get; set; }
        private int[] pages;
        private ICommand deleteCommand;
        private ICommand createCommand;
        private ICommand updateCommand;
        private ICommand previousPageCommand;
        private ICommand nextPageCommand;
        private ICommand lastPageCommand;
        private ICommand firstPageCommand;
        private int pageSize = 15;
        public string sortDirection { get; set; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public ProductCategoryVM()
        {
            createCommand = new RelayCommand(onCreate, CanUserCreate);
            updateCommand = new RelayCommand(onUpdate, CanUserUpdate);
            deleteCommand = new RelayCommand(onDelete, CanUserDelete);
            previousPageCommand = new RelayCommand(onPrevious, CanPreviousPage);
            nextPageCommand = new RelayCommand(onNext, CanNextPage);
            lastPageCommand = new RelayCommand(onLastPage, CanLastPage);
            firstPageCommand = new RelayCommand(onFirstPage, CanFirstPage);


            selectedProductCategory = new ProductCategory();
            productCategoryService = new ProductCategoryService();

            Pages = new int[] { 15, 20, 30 };
        }

        public async Task BindDataAsync()
        {
            JwtResponse<ProductCategory> asb = await this.productCategoryService.ListAll(PageSize, page, sortDirection);
            this.ProductCategories = new ObservableCollection<ProductCategory>(asb.Data);
            this.TotalPage = asb.Total;
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

        public ICommand LastPageCommand
        {
            get
            {
                return lastPageCommand;
            }
            set
            {
                if (lastPageCommand == null)
                    return;
                lastPageCommand = value;
            }
        }

        public ICommand FirstPageCommand
        {
            get
            {
                return firstPageCommand;
            }
            set
            {
                if (firstPageCommand == null)
                    return;
                firstPageCommand = value;
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
                onPropertyChanged("PageSize");
                BindDataAsync();
            }

        }


        public ObservableCollection<ProductCategory> ProductCategories { get => productCategories; set { productCategories = value; onPropertyChanged("ProductCategories"); } }
        public ProductCategory SelectedProductCategory { get => selectedProductCategory; set { selectedProductCategory = value; onPropertyChanged("SelectedProductCategory"); } }
        public int TotalPage { get => totalPage; set { totalPage = value % PageSize > 0 ? (value / PageSize) + 1 : value / PageSize; } }
        public int Page { get => page; set { page = value; onPropertyChanged("Page"); } }

        public int[] Pages { get => pages; set => pages = value; }

        private async void onCreate(object value)
        {
            ProductCategoryEdit addProductCategory = new ProductCategoryEdit();
            EditScreenInitiate("Ekle", "#52BE80", true);
            SelectedProductCategory = new ProductCategory();
            SelectedProductCategory.MerchantId = CurrentMerchantInformation.merchant.Id;
            addProductCategory.DataContext = this;
            addProductCategory.ShowDialog();
            await BindDataAsync();
        }

        private bool CanUserCreate(object value)
        {
            return true;
        }

        private async void onUpdate(object value)
        {
            SelectedProductCategory = (ProductCategory)value;
            ProductCategoryEdit updateProductCategory = new ProductCategoryEdit();
            EditScreenInitiate("Güncelle", "#52BE80", true);
            updateProductCategory.DataContext = this;
            updateProductCategory.ShowDialog();
            await BindDataAsync();
        }

        private bool CanUserUpdate(object value)
        {
            return true;
        }


        private async void onDelete(object value)
        {
            ProductCategoryEdit deleteProductCategory = new ProductCategoryEdit();
            EditScreenInitiate("Sil", "#E74C3C", false);
            SelectedProductCategory = (ProductCategory)value;
            deleteProductCategory.DataContext = this;
            deleteProductCategory.ShowDialog();
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

        private async void onLastPage(object value)
        {
            this.Page = TotalPage;
            await BindDataAsync();
        }

        private bool CanLastPage(object value)
        {
            return true;
        }

        private async void onFirstPage(object value)
        {
            this.Page = 1;
            await BindDataAsync();
        }

        private bool CanFirstPage(object value)
        {
            return true;
        }
        private void EditScreenInitiate(string editType, string buttonColor, bool isEnable)
        {
            EditTitle = "Ürün Kategori " + editType;
            ButtonContent = editType;
            ButtonColor = buttonColor;
            IsEnable = isEnable;
        }
    }
}


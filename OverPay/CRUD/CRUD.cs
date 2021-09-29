using OverPay.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OverPay.CRUD
{
    public abstract class CRUD<T>
    {
        protected ObservableCollection<T> dataList;
        public string editType;
        public string buttonColor;
        public string buttonContent;
        protected bool isEnabled;
        protected ICommand deleteCommand;
        protected ICommand createCommand;
        protected ICommand updateCommand;

        protected CRUD()
        {
            createCommand = new RelayCommand(onCreate, CanUserCreate);
            updateCommand = new RelayCommand(onUpdate, CanUserUpdate);
            deleteCommand = new RelayCommand(onDelete, CanUserDelete);
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

        public virtual async void onCreate(object value)
        {
            EditScreenInitiate("Ekle", "#abd54f", true);
        }

        private bool CanUserCreate(object value)
        {
            return true;
        }

        private void onUpdate(object value)
        {
            EditScreenInitiate("Güncelle", "#abd54f", true);
        }

        private bool CanUserUpdate(object value)
        {
            return true;
        }


        private void onDelete(object value)
        {
            EditScreenInitiate("Sil", "#E74C3C", false);
        }

        private bool CanUserDelete(object value)
        {
            return true;
        }

        void EditScreenInitiate(string editType, string buttonColor, bool isEnable)
        {
            this.editType = "Ürün Kategori " + editType;
            this.buttonContent = editType;
            this.buttonColor = buttonColor;
            this.isEnabled = isEnable;
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OverPay.Model.Cart
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public OverPay.Model.Product.Product Product { get; set; } = new Product.Product();
        public int Quantitiy { get; set; }
        public int TotalPrice { get; set; }
        public Button addbtn = new Button() { Content = "+"};
        public Button minusbtn = new Button() { Content = "-"};
        public Label QuantityLabel = new Label() { Width = 120, HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center, BorderThickness = new Thickness(1, 1, 1, 1),BorderBrush = System.Windows.Media.Brushes.Black };
        public Label PriceLabel = new Label() { Width = 120, HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left };
    }
}

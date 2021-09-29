using OverPay.Model.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace OverPay
{
    public class CallContentData
    {
        public static void AddUserController(Grid grid, UserControl uc)
        {
            if(grid.Children.Count > 0)
            {
                grid.Children.Clear();
                grid.Children.Add(uc);
            }
            else
            {
                grid.Children.Add(uc);
            }
        }
    }
}

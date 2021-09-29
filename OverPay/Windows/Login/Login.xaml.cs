using OverPay.Model.Authentication;
using OverPay.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OverPay.Windows.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Username.Text = "guray";
            Password.Password = "Erdal*1234";
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationService loginService = new AuthenticationService();
            


            if (Username.Text.Length == 0)
            {
                //errormessage.Text = "Enter an email.";
                Username.Focus();
            }
            else
            {
                Login_Button.IsEnabled = false;
                
                try
                {

                var response = await loginService.Login(new User { UserName = Username.Text, Password = Password.Password });
                    if (response.isSuccessed)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show(response.message);
                        Login_Button.IsEnabled = true;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Login_Button.IsEnabled = true;
                }

               
            }
        }
    }
}

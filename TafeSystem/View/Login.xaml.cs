using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private LoginController lc = new LoginController();
        public Login()
        {
            InitializeComponent();
        }
        public void Login_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                int result = lc.LoginIntoSystem(textBoxEmail.Text, Passwordbox1.Password);
                if (result == 1)
                {
                    NavigationService.Navigate(new MenuView());
                }
                else 
                {
                    MessageBox.Show("Invalid Login");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}

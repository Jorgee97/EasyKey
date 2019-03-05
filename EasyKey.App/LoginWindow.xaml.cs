using EasyKey.BL;
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

namespace EasyKey.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            LogOrCreateUser();
        }

        private void LogOrCreateUser()
        {
            var user = new User(username.Text, password.Text);
            var createUser = user.AttempLoginOrCreateConfigFile();

            if (!createUser.Success)
            {
                MessageBox.Show(createUser.Message);
            } else
            {
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
        }
    }
}

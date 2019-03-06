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
using System.Windows.Shapes;

namespace EasyKey.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User UserInformation { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(User user)
        {
            UserInformation = user;
            InitializeComponent();

            var gridPage = new GridPage(UserInformation);
            Content.Navigate(gridPage);
        }

        private void BtnCreatePassword_Click(object sender, RoutedEventArgs e)
        {
            var addAccount = new AddAccount(UserInformation);
            Content.Navigate(addAccount);
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsPage(UserInformation);
            Content.Navigate(settings);
        }
    }
}

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
    public partial class SettingsPage : Page
    {
        public User UserInformation { get; set; }

        public SettingsPage(User userInformation)
        {
            UserInformation = userInformation;
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UpdateConfig_Click(object sender, RoutedEventArgs e)
        {
            UserInformation.Username = Username.Text;
            UserInformation.Password = OldPassword.Text;

            var op = UserInformation.UpdateUserData(NewPassword.Text);

            if (!op.Success) MessageBox.Show(op.Message);
        }
    }
}

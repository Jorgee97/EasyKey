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
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Page
    {
        public User UserInformation { get; set; }
        public AddAccount()
        {
            InitializeComponent();
        }

        public AddAccount(User userInformation)
        {
            UserInformation = userInformation;
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNewAccount();
            ClearFields();
        }

        private void AddNewAccount()
        {
            var account = new Account
            {
                Email = this.Email.Text,
                Name = this.Name.Text,
                Username = this.Username.Text,
                Password = this.Password.Text
            };

            var op = account.AddAccount(UserInformation);
            if (op.Success)
            {
                MessageBox.Show("The new account was created.");
            }
        }

        private void ClearFields()
        {
            Email.Text = String.Empty;
            Name.Text = String.Empty;
            Username.Text = String.Empty;
            Password.Text = String.Empty;
        }
    }
}

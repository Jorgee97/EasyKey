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
    /// Interaction logic for GridPage.xaml
    /// </summary>
    public partial class GridPage : Page
    {
        public User UserInformation { get; set; }
        public GridPage()
        {
            InitializeComponent();
        }

        public GridPage(User userInformation)
        {
            UserInformation = userInformation;
            InitializeComponent();       
        }

        private void DisplayAccounts()
        {
            AccountHolder.ItemsSource = null;
            var account = new Account();
            IEnumerable<Account> accounts = account.GetAccounts(UserInformation);

            AccountHolder.ItemsSource = accounts;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayAccounts();
        }

        private void OptionEdit_Click(object sender, RoutedEventArgs e)
        {
            AccountHolder.IsReadOnly = false;
        }

        private void OptionDelete_Click(object sender, RoutedEventArgs e)
        {
            var account = new Account();
            var op = account.DeleteAccount(UserInformation, (Account)AccountHolder.SelectedItem);

            if (!op.Success) MessageBox.Show(op.Message);
            DisplayAccounts();
        }

        private void AccountHolder_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {            
            var account = (Account)AccountHolder.SelectedItem;

            MessageBox.Show(account.Name);
            AccountHolder.IsReadOnly = true;
        }
    }
}

﻿using EasyKey.BL;
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
            DisplayAccounts();
        }

        private void DisplayAccounts()
        {
            var fileManager = new FileManager();
            List<Account> accounts = fileManager.ReadEasyKeyFile(UserInformation.FilePath);

            foreach (var account in accounts)
            {
                AccountHolder.Items.Add(account);
            }

        }
    }
}

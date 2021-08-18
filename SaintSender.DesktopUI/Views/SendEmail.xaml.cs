﻿using SaintSender.DesktopUI.ViewModels;
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

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for SendEmail.xaml
    /// </summary>
    public partial class SendEmail : Window
    {
        private SendEmailViewModel _vm;
        private string UserName;

        public SendEmail()
        {
            _vm = new SendEmailViewModel();
            DataContext = _vm;
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.SendMail();
            Close();
        }
    }
}

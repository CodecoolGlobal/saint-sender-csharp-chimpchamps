using SaintSender.Core.Models;
using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views;
using System.Windows;
using System.Windows.Controls;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        public int page = 0;

        public MainWindow()
        {
            // set DataContext to the ViewModel object
            _vm = new MainWindowViewModel();
            DataContext = _vm;
            InitializeComponent();
        }
        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.MailList(EmailConnection.SessionUserName, EmailConnection.SessionPassword, page);
        }

        private void Prev_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.MailList(EmailConnection.SessionUserName, EmailConnection.SessionPassword, page);
            page -= 1;
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.MailList(EmailConnection.SessionUserName, EmailConnection.SessionPassword, page);
            page += 1;
        }


        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.Login())
            {
                LoginStateMessage.Visibility = Visibility.Collapsed;
                LoginGrid.Visibility = Visibility.Collapsed;
                ContentGrid.Visibility = Visibility.Visible;
            } else
            {
                LoginStateMessage.Visibility = Visibility.Visible;
                LoginGrid.Visibility = Visibility.Visible;

            }
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.LogOut();
            LoginGrid.Visibility = Visibility.Visible;
            ContentGrid.Visibility = Visibility.Collapsed;

        }

        private void New_Mail_Button_Click(object sender, RoutedEventArgs e)
        {
            SendEmail sendEmail = new SendEmail();
            sendEmail.Show();
        }
    }
}

using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views;
using System.Windows;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;

        public MainWindow()
        {
            // set DataContext to the ViewModel object
            _vm = new MainWindowViewModel();
            DataContext = _vm;
            InitializeComponent();
        }


        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.Login())
            {
                LoginStateMessage.Visibility = Visibility.Collapsed;
                LoginGrid.Visibility = Visibility.Collapsed;
                ContentGrid.Visibility = Visibility.Visible;
                //Core.Models.Inbox.ListMails();
            } else
            {
                LoginStateMessage.Visibility = Visibility.Visible;
            }
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {

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

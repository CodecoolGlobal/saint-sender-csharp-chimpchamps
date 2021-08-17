using SaintSender.DesktopUI.ViewModels;
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
            LoginGrid.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
            _vm.Login();
        }
    }
}

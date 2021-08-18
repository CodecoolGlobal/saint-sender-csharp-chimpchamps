using AE.Net.Mail;
using SaintSender.Core.Interfaces;
using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace SaintSender.DesktopUI.ViewModels
{
    /// <summary>
    /// ViewModel for Main window. Contains all shown information
    /// and necessary service classes to make view functional.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _password;
        private string _body;
        public ObservableCollection<MailMessage> Mails { get; set; }

        /// <summary>
        /// Whenever a property value changed the subscribed event handler is called.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserName)));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public string Body
        {
            get { return _body; }
            set
            {
                _body = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Body)));
            }
        }

        public void MailList(string UserName, string Password, int page)
        {
            this.Mails.Clear();
            foreach (var mail in Inbox.ListMails(UserName, Password, page))
            {
                this.Mails.Add(mail);
            }
        }



        public MainWindowViewModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
            Body = string.Empty;
            Mails = new ObservableCollection<MailMessage>();
        }

        /// <summary>
        /// Call a vendor service and apply its value into <see cref="Greeting"/> property.
        /// </summary>
        public bool Login()
        {

            MailList(this.UserName, this.Password, 0);
            if (Inbox.IsAuthenticated)
            {
                return true;
            }

            else
            {
                return false;
        }
        }

        public void LogOut()
        {
            Core.Models.EmailConnection.LogOut();
        }


    }
}

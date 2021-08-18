﻿using AE.Net.Mail;
using SaintSender.Core.Interfaces;
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
        private ObservableCollection<MailMessage> _mails;

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

        public ObservableCollection<MailMessage> MailList
        {
            get { return _mails; }
            set { _mails = value; }
        }



        public MainWindowViewModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
            Body = string.Empty;
        }

        /// <summary>
        /// Call a vendor service and apply its value into <see cref="Greeting"/> property.
        /// </summary>
        public bool Login()
        {
            MailList = Core.Models.Inbox.ListMails();
            return Core.Models.EmailConnection.SetUp(this.UserName, this.Password); 
        }


    }
}

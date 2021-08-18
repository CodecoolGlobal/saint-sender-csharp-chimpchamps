using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    public class SendEmailViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _userName;
        private string _password;
        private string _destination;
        private string _subject;
        private string _body;

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

        public string Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Destination)));
            }
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subject)));
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

        public SendEmailViewModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
            Destination = string.Empty;
            Subject = string.Empty;
            Body = string.Empty;
        }

        public void SendMail()
        {

            Core.Models.EmailConnection.SendMail("charly.lombardy@gmail.com", "bkhscuykgdupwiuh", this.Destination, this.Subject, this.Body);
        }
    }
}

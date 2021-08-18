using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Net.Mail;

namespace SaintSender.Core.Models
{
    public class Inbox
    {
        static ImapClient IC;
        public static ObservableCollection<MailMessage> MailList = new ObservableCollection<MailMessage>();
        public static bool IsAuthenticated { get; set; }

        public static ObservableCollection<MailMessage> ListMails(string UserName, string Password)
        {
            try
            {
                using (IC = new ImapClient("imap.gmail.com", UserName, Password, AuthMethods.Login, 993, true))
                {
                    EmailConnection.SessionUserName = UserName;
                    EmailConnection.SessionPassword = Password;
                    IC.SelectMailbox("INBOX");
                    var Emails = IC.GetMessages(IC.GetMessageCount() - 25, IC.GetMessageCount(), false).ToList();
                    Emails.Reverse();
                    MailList.Clear();
                    foreach (var Email in Emails)
                    {
                        MailList.Add(Email);
                    }
                    IsAuthenticated = true;
                }
            }
            catch (Exception)
            {
                IsAuthenticated = false;
            }
            return MailList;
        }
    }
}

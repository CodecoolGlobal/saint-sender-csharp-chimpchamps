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
        public static int PageLength = 5;
        public static int ActualPage = 0;


        public static ObservableCollection<MailMessage> ListMails(string UserName, string Password, int page)
        {
            try
            {
                using (IC = new ImapClient("imap.gmail.com", UserName, Password, AuthMethods.Login, 993, true))
                {
                    var MessageCount = IC.GetMessageCount();
                    EmailConnection.SessionUserName = UserName;
                    EmailConnection.SessionPassword = Password;
                    if (MessageCount > PageLength * page & ActualPage + page >= 0)
                    {
                        IC.SelectMailbox("INBOX");
                        var Emails = IC.GetMessages(IC.GetMessageCount() - (PageLength + (PageLength * page)), IC.GetMessageCount() - (PageLength * page), false).ToList();
                        Emails.Reverse();
                        ActualPage = page;
                        MailList.Clear();
                        foreach (var Email in Emails)
                        {
                            MailList.Add(Email);
                        }
                        IsAuthenticated = true;
                    }
                    else
                    {
                        IC.SelectMailbox("INBOX");
                        var Emails = IC.GetMessages(IC.GetMessageCount() - (PageLength + (PageLength * ActualPage)), IC.GetMessageCount() - (PageLength * ActualPage), false).ToList();
                        Emails.Reverse();
                        MailList.Clear();
                        foreach (var Email in Emails)
                        {
                            MailList.Add(Email);
                        }
                        IsAuthenticated = true;
                    }
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

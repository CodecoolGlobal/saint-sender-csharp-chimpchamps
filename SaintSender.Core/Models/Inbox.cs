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
        static string Username = "charly.lombardy@gmail.com";
        static string Password = "bkhscuykgdupwiuh";
        public static ObservableCollection<MailMessage> MailList = new ObservableCollection<MailMessage>();

        public static ObservableCollection<MailMessage> ListMails()
        {

            IC = new ImapClient("imap.gmail.com", Username, Password, AuthMethods.Login, 993, true);
            IC.SelectMailbox("INBOX");
            //var Email = IC.GetMessage(IC.GetMessageCount() - 1);
            var Emails = IC.GetMessages(IC.GetMessageCount() -5, IC.GetMessageCount(), false).ToList();
            Emails.Reverse();
                MailList.Clear();
            foreach (var Email in Emails)
            {
                MailList.Add(Email);
            }
            //IC.DeleteMessage(Email);
            //Console.ReadLine();
            return MailList;
        }
    }
}

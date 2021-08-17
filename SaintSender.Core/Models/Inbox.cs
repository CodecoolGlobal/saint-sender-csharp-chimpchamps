using System;
using System.Collections.Generic;
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
        List<string> Emails = new List<string>();

        public static void ListMails()
        {

            IC = new ImapClient("imap.gmail.com", Username, Password, AuthMethods.Login, 993, true);
            IC.SelectMailbox("INBOX");
            //var Email = IC.GetMessage(IC.GetMessageCount() - 1);
            var Emails = IC.GetMessages(IC.GetMessageCount() -5, IC.GetMessageCount() +1, false).ToList();
            Emails.Reverse();
            foreach (var Email in Emails)
            {
                Console.WriteLine("Your email: {0}\n", Email.Body); ;
            }
            //IC.DeleteMessage(Email);
            //Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AE.Net.Mail;

namespace SaintSender.Core.Models
{
    public class EmailConnection
    {
        //static string UserName = "charly.lombardy@gmail.com";
        //static string Password = "bkhscuykgdupwiuh";
        //static string Subject = "Test mail";
        //static string Body = "Login teszt";
        //static string Destination = "charly.lombardy@gmail.com";

        public static string SessionUserName{ get; set; }
        public static string SessionPassword{ get; set; }
        public static bool SetUp(String UserName, String Password)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(UserName, Password);
                    SessionUserName = UserName;
                    SessionPassword = Password;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static void SendMail(String Destination, String Subject, String Body)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(SessionUserName, SessionPassword);

                    System.Net.Mail.MailMessage msgObj = new System.Net.Mail.MailMessage();
                    msgObj.To.Add(Destination);
                    msgObj.From = new MailAddress(SessionUserName);
                    msgObj.Subject = Subject;
                    msgObj.Body = Body;
                    client.Send(msgObj);
                }
            }
            catch
            {
            }
        }
    }
}

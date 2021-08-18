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
        public static bool SetUp(String UserName, String Password, String Body)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(UserName, "bkhscuykgdupwiuh");
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static void SendMail(String UserName, String Password, String Destination, String Subject, String Body)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(UserName, Password);

                    System.Net.Mail.MailMessage msgObj = new System.Net.Mail.MailMessage();
                    msgObj.To.Add(Destination);
                    msgObj.From = new MailAddress(UserName);
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

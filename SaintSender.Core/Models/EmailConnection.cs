using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Models
{
    public class EmailConnection
    {
        static string Username = "charly.lombardy@gmail.com";
        static string Password = "bkhscuykgdupwiuh";
        static string Subject = "Test mail";
        static string Body = "BBBBBBBBBANNNNÁÁÁÁNNNNNN!!!";
        static string Destination = "charly.lombardy@gmail.com";
        public static void SetUp()
        {
            //Console.WriteLine("Username:");
            //Username = Console.ReadLine();

            //Console.WriteLine("Password:");
            //Password = Console.ReadLine();

            //Console.WriteLine("Subject:");
            //Subject = Console.ReadLine();

            //Console.WriteLine("Body:");
            //Body = Console.ReadLine();

            //Console.WriteLine("Destination:");
            //Destination = Console.ReadLine();

            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(Username, Password);
                    MailMessage msgObj = new MailMessage();
                    msgObj.To.Add(Destination);
                    msgObj.From = new MailAddress(Username);
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

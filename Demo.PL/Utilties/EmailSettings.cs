using System.Net.Mail;
using System.Net;

namespace Demo.PL.Utilties
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("routemaha@gmail.com", "ilpmmfybmqtcdvxd");
            client.Send("routemaha@gmail.com", email.To, email.Subject, email.Body);
        }

    }
}

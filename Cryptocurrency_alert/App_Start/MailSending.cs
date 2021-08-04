using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Cryptocurrency_alert.App_Start
{
    public class MailSending : IMailSending
    {
        private Email email = new Email();
        private MimeMessage message;

        public MailSending()
        {
            message = new MimeMessage();
        }

        public void AssignContacts(string aFrom = "cryptocurrency.alert4@gmail.com", string aTo = "szlosekwojciech@gmail.com")
        {
            email.aFrom = aFrom;
            email.aTo = aTo;
        }

        public void AssignContent(string text = "testowa wiadomosc")
        {
            email.text = text;
        }

        public void SendMail()
        {
            message.From.Add(new MailboxAddress("Cryptocurrency alert", email.aFrom));
            message.To.Add(new MailboxAddress("Wojciech Szlosek", email.aTo));
            message.Subject = "Wysłał mnie C#!!!";
            message.Body = new TextPart("plain")
            {
                Text = email.text
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(email.aFrom, password: "kryptowaluty");
                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}

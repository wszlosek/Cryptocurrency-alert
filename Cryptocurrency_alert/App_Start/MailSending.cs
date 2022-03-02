using System;
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

        public void AssignContacts(string aFrom = "cryptocurrency.alert4@gmail.com", string aTo = "")
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
            message.To.Add(new MailboxAddress("", email.aTo));

            DateTime thisDay = DateTime.Now;
            message.Subject = "Cryptocurrency alert - " + thisDay.ToString("g");

            message.Body = new TextPart("plain")
            {
                Text = email.text
            };

            var emailBody = new BodyBuilder();
            emailBody.TextBody = email.text;
            emailBody.Attachments.Add(@"/Users/wojciechszlosek/Desktop/Cryptocurrency-alert/Cryptocurrency_alert/cryptocurrency.pdf");

            message.Body = emailBody.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("cryptocurrency.alert4@gmail.com", password: "kryptowaluty");
                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}

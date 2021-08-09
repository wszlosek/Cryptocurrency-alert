using System;

namespace Cryptocurrency_alert.App_Start
{
    public interface IMailSending
    {
        void SendMail();
        void AssignContacts(string aFrom = "cryptocurrency.alert4@gmail.com",
            string aTo = "");
        void AssignContent(string text);
    }
}

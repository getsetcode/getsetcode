using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using getsetcode.Helpers;
using System.Net;

namespace getsetcode.Business.Communicators
{
    public class SmtpService : ISmtpService
    {
        private SmtpClient _mailClient;

        public SmtpService()
        {
            _mailClient = new SmtpClient();
            _mailClient.Host = EmmaMorris.SmtpServer;
            _mailClient.Port = EmmaMorris.SmtpPort;
            _mailClient.Credentials = new NetworkCredential(EmmaMorris.SmtpUsername, EmmaMorris.SmtpPassword);
            _mailClient.EnableSsl = true;
        }

        public void SendToMe(MailAddress from, string subject, string message)
        {
            var m = new MailMessage(from, new MailAddress(EmmaMorris.EmailRecipientAddress, EmmaMorris.EmailRecipientName));

            m.Subject = subject;
            m.Body = string.Format("{0}\n\n----------------\nFrom: {1} ({2})", message, from.DisplayName, from.Address);
            m.IsBodyHtml = false;

            _mailClient.Send(m);
        }
    }
}

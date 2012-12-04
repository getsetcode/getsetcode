using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace getsetcode.Business.Communicators
{
    public interface ISmtpService
    {
        void SendToMe(MailAddress from, string subject, string message);
    }
}

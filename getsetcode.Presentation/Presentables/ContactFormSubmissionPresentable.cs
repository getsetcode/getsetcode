using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Presentation.Presentables
{
    public class ContactFormSubmissionPresentable : IContactFormSubmissionPresentable
    {
        ContactFormSubmission _base;

        public ContactFormSubmissionPresentable(ContactFormSubmission submission)
        {
            _base = submission;
        }

        #region Raw Properties

        public int SubmissionId { get { return _base.SubmissionId; } }

        public string Name { get { return _base.Name; } }

        public string EmailAddress { get { return _base.EmailAddress; } }

        public string Message { get { return _base.Message; } }

        public bool MailingList { get { return _base.MailingList; } }

        public System.DateTime DateStamp { get { return _base.DateStamp; } }

        public bool EmailSent { get { return _base.EmailSent; } }

        #endregion

        public string DisplayDate
        {
            get { return _base.DateStamp.ToString("dd/MM/yyyy"); }
        }

        public string DisplayMessage
        {
            get { return _base.Message.Replace("\n", "<br>"); }
        }
    }
}

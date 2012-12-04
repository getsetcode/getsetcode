using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Presentation.Presentables
{
    public interface IContactFormSubmissionPresentable
    {
        int SubmissionId { get; }
        
        string Name { get; }
        
        string EmailAddress { get; }
        
        string Message { get; }
        
        bool MailingList { get; }
        
        System.DateTime DateStamp { get; }
        
        bool EmailSent { get; }

        string DisplayDate { get; }

        string DisplayMessage { get; }
    }
}

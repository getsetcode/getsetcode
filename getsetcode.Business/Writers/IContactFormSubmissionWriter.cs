using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Writers
{
    public interface IContactFormSubmissionWriter
    {
        void Save(ContactFormSubmission submission);
    }
}

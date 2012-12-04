using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public interface IContactFormSubmissionReader
    {
        ContactFormSubmission Get(int id);

        IEnumerable<ContactFormSubmission> List(DateTime? olderThan, int take);
    }
}

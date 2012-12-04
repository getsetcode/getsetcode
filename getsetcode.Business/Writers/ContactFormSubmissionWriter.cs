using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Writers
{
    public class ContactFormSubmissionWriter : IContactFormSubmissionWriter
    {
        IContextAccessor _accessor;

        public ContactFormSubmissionWriter(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public void Save(ContactFormSubmission submission)
        {
            using (var c = _accessor.Context())
            {
                c.Context.ContactFormSubmissions.AddObject(submission);
                c.Context.SaveChanges();
            }
        }
    }
}

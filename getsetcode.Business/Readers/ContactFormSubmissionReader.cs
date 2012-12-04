using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public class ContactFormSubmissionReader : IContactFormSubmissionReader
    {
        IContextAccessor _accessor;

        public ContactFormSubmissionReader(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public ContactFormSubmission Get(int id)
        {
            using (var c = _accessor.Context())
            {
                return c.Context.ContactFormSubmissions
                    .SingleOrDefault(s => s.SubmissionId == id);
            }
        }
        
        public IEnumerable<ContactFormSubmission> List(DateTime? olderThan, int take)
        {
            using (var c = _accessor.Context())
            {
                return c.Context.ContactFormSubmissions
                    .OrderByDescending(s => s.DateStamp)
                    .Where(s => !olderThan.HasValue || s.DateStamp < olderThan)
                    .Take(take)
                    .ToList();
            }
        }
    }
}

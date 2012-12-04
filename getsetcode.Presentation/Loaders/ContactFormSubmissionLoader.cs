using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Business.Readers;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Presentation.Loaders
{
    public class ContactFormSubmissionLoader : IContactFormSubmissionLoader
    {
        IContactFormSubmissionReader _reader;

        public ContactFormSubmissionLoader(IContactFormSubmissionReader reader)
        {
            _reader = reader;
        }

        public IContactFormSubmissionPresentable GetPresentable(int id)
        {
            var s = _reader.Get(id);
            if (s == null) return null;
            else return new ContactFormSubmissionPresentable(s);
        }

        public IEnumerable<IContactFormSubmissionPresentable> ListPresentables(DateTime? olderThan, int take)
        {
            foreach (var s in _reader.List(olderThan, take))
            {
                yield return new ContactFormSubmissionPresentable(s);
            }
        }
    }
}

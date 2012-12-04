using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Model;
using getsetcode.Presentation.Loaders;

namespace getsetcode.Web.Services
{
    public class ContactFormFactory : IContactFormFactory
    {
        IContactFormSubmissionLoader _loader;
        ICookieHandler _cookieHandler;

        public ContactFormFactory(IContactFormSubmissionLoader loader, ICookieHandler cookieHandler)
        {
            _loader = loader;
            _cookieHandler = cookieHandler;
        }

        public ContactFormSubmission NewSubmission
        {
            get
            {
                var s = new ContactFormSubmission();

                // Pre-fill name and email address fields if previous submission ID stored in cookie
                var id = _cookieHandler.LastContactFormSubmissionID;
                if (id.HasValue)
                {
                    var sp = _loader.GetPresentable(id.Value);
                    if (sp != null)
                    {
                        s.Name = sp.Name;
                        s.EmailAddress = sp.EmailAddress;
                    }
                }

                return s;
            }
        }
    }
}
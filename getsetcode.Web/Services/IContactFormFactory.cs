using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Web.Services
{
    public interface IContactFormFactory
    {
        ContactFormSubmission NewSubmission { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Web.Services
{
    public interface ICookieHandler
    {
        int? LastContactFormSubmissionID { get; set; }
    }
}

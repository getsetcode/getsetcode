using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Models.Contact
{
    public class RecentContactsData
    {
        public List<IContactFormSubmissionPresentable> Submissions { get; set; }
    }
}
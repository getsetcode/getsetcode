using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Model;

namespace getsetcode.Web.Models.Shared
{
    public class ContactFormData
    {
        public MainSideBarData MainSideBarData { get; set; }
 
        public ContactFormSubmission Submission { get; set; }

        public bool Modal { get; set; }

        public List<string> Errors { get; set; }

        public bool HasErrors { get { return Errors != null && Errors.Count > 0; } }
    }
}
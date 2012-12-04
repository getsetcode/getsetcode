using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getsetcode.Web.Models.Blog
{
    public class BlogPost
    {
        public string ID { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool FirstPost { get; set; }
    }
}
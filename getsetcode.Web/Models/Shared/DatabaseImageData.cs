using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Model;

namespace getsetcode.Web.Models.Shared
{
    public class DatabaseImageData
    {
        public string FilePath { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string AltText { get; set; }

        public string CssClass { get; set; }
    }
}
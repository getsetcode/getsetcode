using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Model.Enum;
using System.Text;
using getsetcode.Presentation.MvcHelpers;

namespace getsetcode.Web.Services
{
    public static class TitleBuilder
    {
        public static string Get(NavSection section, string node = null)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("GETSETCODE / {0}", ControllerHelper.Text(section));

            if (!string.IsNullOrEmpty(node))
            {
                sb.AppendFormat(" / {0}", node);
            }

            return sb.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using getsetcode.Model.Enum;
using getsetcode.Presentation.MvcHelpers;

namespace getsetcode.Web.Extensions.HelperExtensions
{
    public static class Navigation
    {
        public static MvcHtmlString MainNavListItem(this HtmlHelper html, NavSection thisSection, NavSection activeSection, string linkClass = null)
        {
            return MvcHtmlString.Create(string.Format("<li class=\"{0}\">{1}</li>",
                activeSection == thisSection ? "active" : "",
                html.ActionLink(ControllerHelper.Text(thisSection), "Index", ControllerHelper.Controller(thisSection), null, new { title = ControllerHelper.Controller(thisSection), @class = linkClass })));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;
using getsetcode.Model.Enum;
using getsetcode.Model;
using getsetcode.Model.Interface;
using getsetcode.Presentation;
using getsetcode.Presentation.MvcHelpers;

namespace getsetcode.Web.Extensions.HelperExtensions
{
    public static class Links
    {
        #region Private

        private static string _clientDetailAction = "ClientDetail";

        private static RouteValueDictionary clientDetailRouteValues(IClient c)
        {
            return new RouteValueDictionary(new { id = c.ShortName });
        }

        #endregion

        public static string ClientDetail(this UrlHelper url, IClient c)
        {
            return url.Action(_clientDetailAction, ControllerHelper.Controller(NavSection.Portfolio), clientDetailRouteValues(c));
        }
    }
}
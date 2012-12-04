using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;
using getsetcode.Model.Interface;
using getsetcode.Model;

namespace getsetcode.Presentation.MvcHelpers
{
    public static class HtmlHelperExtensions
    {
        private static RouteValueDictionary routeValuesForILink(ILink l)
        {
            return new RouteValueDictionary(new { id = l.LinkStringID });
        }

        public static MvcHtmlString DetailLink(this HtmlHelper html, ILink l, string cssClass = null, TipType? tip = null, string linkText = null, int? returnProjectID = null, int? returnClientID = null)
        {
            var rv = routeValuesForILink(l);
            if (returnProjectID.HasValue && returnClientID.HasValue)
            {
                throw new Exception("Cannot handle two different return types");
            }
            else if (returnProjectID.HasValue)
            {
                rv.Add("project", returnProjectID.Value);
            }
            else if (returnClientID.HasValue)
            {
                rv.Add("client", returnClientID.Value);
            }
            if (linkText == null) linkText = l.LinkName;
            if (tip == null)
                return html.simpleActionLink(linkText, rv, ControllerHelper.Controller(l.Section), l.DetailAction, cssClass);
            else
                return html.popoverActionLink(linkText, l.LinkInfo, tip.Value, rv, ControllerHelper.Controller(l.Section), l.DetailAction, cssClass);
        }

        public static MvcHtmlString ImageLink(this HtmlHelper html, ILink l, Image image, string cssClass = null)
        {
            var urlHelper = ((Controller)html.ViewContext.Controller).Url;
            var photoUrl = urlHelper.Content(Content.DatabaseImagePath(image.FileName));
            var rv = routeValuesForILink(l);

            var img = new TagBuilder("img");
            img.MergeAttribute("src", photoUrl);
            img.MergeAttribute("alt", l.LinkName);
            img.MergeAttribute("width", image.Width.ToString());
            img.MergeAttribute("height", image.Height.ToString());
            if (!string.IsNullOrWhiteSpace(cssClass)) 
                img.MergeAttribute("class", cssClass);

            var imglink = new TagBuilder("a");
            imglink.MergeAttribute("href", urlHelper.Action(l.DetailAction, ControllerHelper.Controller(l.Section), rv));
            img.MergeAttribute("title", l.LinkName);
            imglink.InnerHtml = img.ToString(TagRenderMode.SelfClosing);

            return MvcHtmlString.Create(imglink.ToString());
        }

        /*
            UrlHelper urlHelper = ((Controller)html.ViewContext.Controller).Url;
            string imgtag = html.Image(imgSrc, alt, imgHtmlAttributes);
            string url = urlHelper.Action(actionName, controllerName, routeValues);

            TagBuilder imglink = new TagBuilder("a");
            imglink.MergeAttribute("href", url);
            imglink.InnerHtml = imgtag;
            imglink.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

            return imglink.ToString();
         */

        private static MvcHtmlString simpleActionLink(this HtmlHelper html, string title, RouteValueDictionary rv, string controller, string action, string cssClass = null)
        {
            var y = new Dictionary<string, object>();
            y.Add("title", title);
            if (!string.IsNullOrEmpty(cssClass)) y.Add("class", cssClass);

            return html.ActionLink(title, action, controller, rv, y);
        }

        private static MvcHtmlString popoverActionLink(this HtmlHelper html, string title, string content, TipType tip, RouteValueDictionary rv, string controller, string action, string cssClass = null)
        {
            var y = new Dictionary<string, object>();
            y.Add("title", title);
            if (!string.IsNullOrEmpty(cssClass)) y.Add("class", cssClass);
            y.Add("rel", "popover");
            y.Add("data-content", content);
            if (y.ContainsKey("class")) y["class"] = string.Format("{0} {1}", y["class"], tipClass(tip));
            else y.Add("class", tipClass(tip));

            return html.ActionLink(title, action, controller, rv, y);
        }

        private static string tipClass(TipType type)
        {
            switch (type)
            {
                // Previously tip position was explicit, now it determined based on location cient-side
                //case TipType.Over: return "tip-over";
                //case TipType.After: return "tip-after";
                //case TipType.Below: return "tip-below";
                //case TipType.Before: return "tip-before";
                case TipType.Over:
                case TipType.After: 
                case TipType.Below: 
                case TipType.Before:
                    return "tip-me";
                default: 
                    throw new Exception(string.Format("Unhandled tip type: {0}", type));
            }
        }
    }
}

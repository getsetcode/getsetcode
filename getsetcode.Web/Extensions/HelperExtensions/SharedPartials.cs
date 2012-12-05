using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using getsetcode.Model.Enum;
using getsetcode.Web.Models.Shared;
using getsetcode.Model;
using getsetcode.Helpers;
using getsetcode.Model.Interface;
using getsetcode.Presentation.Presentables;
using getsetcode.Presentation.MvcHelpers;

namespace getsetcode.Web.Extensions.HelperExtensions
{
    public static class SharedPartials
    {
        public static string CvDownloadPartialName { get { return "CvDownload"; } }

        public static MvcHtmlString SiteHeader(this HtmlHelper html, NavSection section)
        {
            return html.Partial("SiteHeader", section);
        }

        public static MvcHtmlString MainSideBar(this HtmlHelper html, MainSideBarData data)
        {
            return html.Partial("MainSideBar", data);
        }

        public static MvcHtmlString LeftSideLogo(this HtmlHelper html, bool inLozenge)
        {
            return html.Partial("LeftSideLogo", new LeftSideLogoData() { InLozenge = inLozenge });
        }

        public static MvcHtmlString ImageGalleryModal(this HtmlHelper html)
        {
            return html.Partial("ImageGalleryModal");
        }

        public static MvcHtmlString DefaultPersonImage(this HtmlHelper html, IPerson person, string cssClass = null)
        {
            return html.Partial("DatabaseImage", new DatabaseImageData() 
            { 
                FilePath = Content.DefaultPersonImagePath(),
                AltText = person.Name,
                Width = EmmaMorris.DefaultPersonImageSize,
                Height = EmmaMorris.DefaultPersonImageSize,
                CssClass = cssClass 
            });
        }

        public static MvcHtmlString DatabaseImage(this HtmlHelper html, Image image, string cssClass = null)
        {
            return html.Partial("DatabaseImage", new DatabaseImageData()
            {
                FilePath = Content.DatabaseImagePath(image.FileName),
                AltText = image.Title,
                Width = image.Width,
                Height = image.Height,
                CssClass = cssClass
            });
        }

        public static MvcHtmlString TestimonialImage(this HtmlHelper html, IPersonPresentable person, string cssClass = null)
        {
            if (person.Thumbnail != null)
                return html.DatabaseImage(person.Thumbnail, cssClass);
            else
                return html.DefaultPersonImage(person, cssClass);
        }

        public static MvcHtmlString CvDownload(this HtmlHelper html, CurriculumVitae cv)
        {
            return html.Partial(CvDownloadPartialName, cv);
        }

        public static MvcHtmlString BrandName(this HtmlHelper html)
        {
            return html.Partial("BrandName");
        }

        public static MvcHtmlString AboutTom(this HtmlHelper html, bool includeIntro)
        {
            return html.Partial("AboutTom", new AboutTomData() { IncludeIntro = includeIntro });
        }

        public static MvcHtmlString Quote(this HtmlHelper html, string quote)
        {
            return html.Partial("Quote", (object)quote);
        }

        public static MvcHtmlString HistoryItem(this HtmlHelper html, IHistoryItemPresentable historyItem)
        {
            if (historyItem.Client != null)
                return html.Partial("History/ClientHistoryItem", historyItem);
            else if (historyItem.Project != null)
                return html.Partial("History/ProjectHistoryItem", historyItem);
            else if (historyItem.Testimonial != null)
                return html.Partial("History/TestimonialHistoryItem", historyItem);
            else return null;
        }

        public static MvcHtmlString ProjectInList(this HtmlHelper html, ProjectInListData data)
        {
            return html.Partial("ProjectInList", data);
        }

        public static MvcHtmlString TestimonialPostContent(this HtmlHelper html, ITestimonialPresentable testimonial)
        {
            return html.Partial("TestimonialPostContent", testimonial);
        }

        public static MvcHtmlString ContactForm(this HtmlHelper html, ContactFormData data)
        {
            return html.Partial("ContactForm", data);
        }

        public static MvcHtmlString Modal(this HtmlHelper html)
        {
            return html.Partial("Modal");
        }

        public static MvcHtmlString AvailableOnGitHub(this HtmlHelper html)
        {
            return html.Partial("AvailableOnGitHub");
        }

        public static MvcHtmlString SiteFooter(this HtmlHelper html)
        {
            return html.Partial("SiteFooter");
        }
    }
}
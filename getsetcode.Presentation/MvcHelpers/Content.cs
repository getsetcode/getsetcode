using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Helpers;

namespace getsetcode.Presentation.MvcHelpers
{
    public static class Content
    {
        public static string DefaultPersonImagePath()
        {
            return string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, EmmaMorris.DefaultPersonImageFileName);
        }

        public static string DatabaseImagePath(string fileName)
        {
            return string.Format("{0}{1}", EmmaMorris.DatabaseImageRoot, fileName);
        }

        public static string ContentLargeLogo(this UrlHelper url)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, "gsc-logo-transparent.png"));
        }

        public static string ContentLoadingGif(this UrlHelper url)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, "loading.gif"));
        }

        public static string ButtonLoadingGif(this UrlHelper url)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, "button-loading.gif"));
        }

        public static string IconForWord(this UrlHelper url)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, "icon-word.png"));
        }

        public static string IconForPdf(this UrlHelper url)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, "icon-pdf.png"));
        }

        public static string ContentImageHeaderLogo(this UrlHelper url)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, "gsc-logo-stripes.png"));
        }

        public static string ContentImageQuoteOpen(this UrlHelper url)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, "double-quote-open.gif"));
        }

        public static string ContentImageQuoteClose(this UrlHelper url)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, "double-quote-Close.gif"));
        }

        public static string ContentImage(this UrlHelper url, string fileName)
        {
            return url.Content(string.Format("{0}{1}", EmmaMorris.DefaultImageRoot, fileName));
        }

        public static string DefaultPersonImage(this UrlHelper url, string fileName)
        {
            return url.Content(DefaultPersonImagePath());
        }

        public static string DatabaseImage(this UrlHelper url, string fileName)
        {
            return url.Content(DatabaseImagePath(fileName));
        }
    }
}
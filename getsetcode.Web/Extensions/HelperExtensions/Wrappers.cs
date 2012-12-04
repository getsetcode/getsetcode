using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace getsetcode.Web.Extensions.HelperExtensions
{
    public static class Wrappers
    {
        private class DivWrapper : IDisposable
        {
            private readonly TextWriter _writer;
            public DivWrapper(TextWriter writer)
            {
                _writer = writer;
            }

            public void Dispose()
            {
                _writer.Write("</div>");
            }
        }

        public static IDisposable Row(this HtmlHelper html)
        {
            return div(html, "row");
        }

        public static IDisposable FullWidthPanel(this HtmlHelper html)
        {
            return div(html, "span12");
        }

        public static IDisposable FourColumnPanel(this HtmlHelper html)
        {
            return div(html, "span4");
        }

        public static IDisposable EightColumnPanel(this HtmlHelper html)
        {
            return div(html, "span8");
        }

        public static IDisposable Window(this HtmlHelper html, bool centred)
        {
            return div(html, centred ? "window centered" : "window");
        }

        public static IDisposable Wall(this HtmlHelper html, string heading = null)
        {
            var writer = openDiv(html, "wall");

            if (!string.IsNullOrEmpty(heading))
                writer.WriteLine(string.Format("<h3>{0}</h3>", heading));

            return new DivWrapper(writer);
        }

        private static IDisposable div(HtmlHelper html, string cssClass)
        {
            var writer = openDiv(html, cssClass);

            return new DivWrapper(writer);
        }

        private static TextWriter openDiv(HtmlHelper html, string cssClass)
        {
            var writer = html.ViewContext.Writer;

            writer.WriteLine(string.Format("<div class=\"{0}\">", cssClass));

            return writer;
        }
    }
}
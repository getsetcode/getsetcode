using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using getsetcode.Web.Models.Shared;
using getsetcode.Model.Enum;

namespace getsetcode.Web.Extensions.HelperExtensions
{
    public static class Messages
    {
        public static MvcHtmlString ErrorMessage(this HtmlHelper html, string message, bool closeable = false)
        {
            return html.ErrorMessage(new List<string>() { message }, closeable);
        }

        public static MvcHtmlString ErrorMessage(this HtmlHelper html, List<string> messages, bool closeable = false)
        {
            return html.Partial("Message", new MessageData()
                {
                    Closeable = closeable, 
                    Messages = messages, 
                    MessageType = MessageType.Error
                });
        }

        public static MvcHtmlString WarningMessage(this HtmlHelper html, string message, bool closeable = false)
        {
            return html.Partial("Message", new MessageData()
            {
                Closeable = closeable,
                Messages = new List<string>() { message },
                MessageType = MessageType.Warning
            });
        }

        public static MvcHtmlString InfoMessage(this HtmlHelper html, string message, bool closeable = false)
        {
            return html.Partial("Message", new MessageData()
            {
                Closeable = closeable,
                Messages = new List<string>() { message },
                MessageType = MessageType.Info
            });
        }

        public static MvcHtmlString SuccessMessage(this HtmlHelper html, string message, bool closeable = false)
        {
            return html.Partial("Message", new MessageData()
            {
                Closeable = closeable,
                Messages = new List<string>() { message },
                MessageType = MessageType.Success
            });
        }
    }
}
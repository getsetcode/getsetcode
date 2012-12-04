using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getsetcode.Web.Services
{
    public class CookieHandler : ICookieHandler
    {
        string _cookieName = "GETSETCODE";
        HttpContext _httpContext;

        public CookieHandler(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public int? LastContactFormSubmissionID
        {
            get
            {
                int id;
                if (int.TryParse(getValue("lcfs"), out id))
                    return id;
                else
                    return null;
            }
            set
            {
                if (value == null)
                    removeValue("lcfs");
                else
                    setValue("lcfs", value.ToString());
            }
        }

        private HttpCookie _cookie
        {
            get
            {
                HttpCookie c;
                c = _httpContext.Request.Cookies[_cookieName];
                if (c == null)
                    c = new HttpCookie(_cookieName);

                return c;
            }
            set
            {
                _httpContext.Response.Cookies.Add(value);
            }
        }

        private string getValue(string key)
        {
            var c = _cookie;
            if (c.Values.AllKeys.Contains(key))
                return c.Values[key];
            else
                return null;
        }

        private void setValue(string key, string value)
        {
            var c = _cookie;
            if (c.Values.AllKeys.Contains(key))
                c.Values[key] = value;
            else
                c.Values.Add(key, value);
            _cookie = c;
        }

        private void removeValue(string key)
        {
            var c = _cookie;
            if (c.Values.AllKeys.Contains(key))
                c.Values.Remove(key);
            _cookie = c;
        }
    }
}
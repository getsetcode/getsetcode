using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;
using getsetcode.Model.Enum;
using getsetcode.Presentation.StringHelpers;
using System.Web.Mvc;

namespace getsetcode.Presentation.Presentables
{
    public class ClientPresentable : IClientPresentable
    {
        Client _base;

        public ClientPresentable(Client client)
        {
            _base = client;
        }

        #region Raw Properties

        public int ClientId { get { return _base.ClientId; } }

        public string Name { get { return _base.Name; } }

        public string ShortName { get { return _base.ShortName; } }

        public string Address { get { return _base.Address; } }

        public string BriefDescription { get { return _base.BriefDescription; } }

        //public string SummaryHtml { get { return _base.SummaryHtml; } }

        public string Website { get { return _base.Website; } }

        public bool Featured { get { return _base.Featured; } }

        #endregion

        #region ILink Members

        public int LinkID { get { return _base.ClientId; } }

        public string LinkStringID { get { return _base.ShortName; } }

        public string LinkName { get { return _base.Name; } }

        public string LinkInfo { get { return _base.BriefDescription; } }

        public string DetailAction { get { return "ClientDetail"; } }

        public NavSection Section { get { return NavSection.Portfolio; } }

        #endregion

        private string _summaryHtml;
        public string SummaryHtml
        {
            get
            {
                if (_summaryHtml == null)
                {
                    _summaryHtml = HtmlPresenter.HideInContentLinks(_base.SummaryHtml);
                }
                return _summaryHtml;
            }
        }

        private string _summaryHtmlWithLinks;
        public string SummaryHtmlWithLinks(HtmlHelper html)
        {
            if (_summaryHtmlWithLinks == null)
            {
                _summaryHtmlWithLinks = html.FormatInContentLinks(_base.SummaryHtml, projects: Projects, returnClientID: this.ClientId);
            }
            return _summaryHtmlWithLinks;
        }

        public List<IProjectPresentable> Projects
        {
            get
            {
                return _base.Projects
                    .Select(p => new ProjectPresentable(p))
                    .Cast<IProjectPresentable>()
                    .OrderByDescending(p => p.LastWorked)
                    .ToList();
            }
        }

        public List<ITestimonialPresentable> Testimonials
        {
            get
            {
                return _base.Testimonials
                    .Select(t => new TestimonialPresentable(t))
                    .Cast<ITestimonialPresentable>()
                    .OrderByDescending(t => t.Date)
                    .ToList();
            }
        }

        public Image Logo
        {
            get { return _base.Logo; }
        }

        public string WebsiteDisplay
        {
            get
            {
                if (string.IsNullOrEmpty(Website)) return null;
                else return Website.Replace("http://", "").Replace("https://", "");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Interface;
using getsetcode.Model;
using System.Web.Mvc;

namespace getsetcode.Presentation.Presentables
{
    public interface IClientPresentable : IClient, ILink
    {
        string SummaryHtmlWithLinks(HtmlHelper html);

        List<IProjectPresentable> Projects { get; }

        List<ITestimonialPresentable> Testimonials { get; }

        Image Logo { get; }

        string WebsiteDisplay { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Interface;
using getsetcode.Model;
using System.Web.Mvc;

namespace getsetcode.Presentation.Presentables
{
    public interface IProjectPresentable : IProject, ILink
    {
        string SummaryHtmlWithLinks(HtmlHelper html);

        IClientPresentable Client { get; }

        Image ThumbnailImage { get; }

        List<Image> ImagesWithThumbnails { get; }

        List<ISkillPresentable> FeaturedSkills { get; }

        List<ISkillPresentable> AllSkills { get; }

        List<string> Responsibilities { get; }

        DateTime LastWorked { get; }

        string MonthSpan { get; }

        string YearSpan { get; }

        int YearLastWorked { get; }
    }
}

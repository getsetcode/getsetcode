using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using getsetcode.Model;
using getsetcode.Model.Enum;
using getsetcode.Presentation.MvcHelpers;
using getsetcode.Presentation.StringHelpers;

namespace getsetcode.Presentation.Presentables
{
    public class ProjectPresentable : IProjectPresentable
    {
        Project _base;

        public ProjectPresentable(Project project)
        {
            _base = project;
        }

        #region Raw Properties

        public int ProjectId { get { return _base.ProjectId; } }

        public string Name { get { return _base.Name; } }

        public string ShortName { get { return _base.ShortName; } }

        public string BriefSummary { get { return _base.BriefSummary; } }

        // Overridden below
        // public string SummaryHtml { get { return _base.SummaryHtml; } }

        public bool Featured { get { return _base.Featured; } }

        #endregion

        #region ILink Members

        public int LinkID { get { return _base.ProjectId; } }

        public string LinkStringID { get { return _base.ShortName; } }

        public string LinkName { get { return _base.Name; } }

        public string LinkInfo { get { return _base.BriefSummary; } }

        public string DetailAction { get { return "Detail"; } }

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
                _summaryHtmlWithLinks = html.FormatInContentLinks(_base.SummaryHtml, skills: AllSkills, clients: new List<IClientPresentable>() { Client }, returnProjectID: this.ProjectId);
            }
            return _summaryHtmlWithLinks; 
        }

        public IClientPresentable Client { get { return new ClientPresentable(_base.Client); } }

        public Image ThumbnailImage { get { return _base.ThumbnailImage; } }

        private List<Image> _imagesWithThumbnails;
        public List<Image> ImagesWithThumbnails
        {
            get
            {
                if (_imagesWithThumbnails == null)
                {
                    _imagesWithThumbnails = _base.ProjectImages
                        .OrderBy(i => i.Rank)
                        .Select(i => i.Image)
                        .Where(i => i.Thumbnail != null)
                        .ToList();
                }
                return _imagesWithThumbnails;
            }
        }

        private List<ISkillPresentable> _allSkills;
        public List<ISkillPresentable> AllSkills
        {
            get
            {
                if (_allSkills == null)
                {
                    _allSkills = _base.ProjectSkills
                        .OrderBy(s => s.Rank)
                        .Select(s => new SkillPresentable(s.Skill))
                        .Cast<ISkillPresentable>()
                        .ToList();
                }
                return _allSkills;
            }
        }

        private List<ISkillPresentable> _featuredSkills;
        public List<ISkillPresentable> FeaturedSkills
        {
            get
            {
                if (_featuredSkills == null)
                {
                    _featuredSkills = _base.ProjectSkills
                        .Where(s => s.Featured)
                        .OrderBy(s => s.Rank)
                        .Select(s => new SkillPresentable(s.Skill))
                        .Cast<ISkillPresentable>()
                        .ToList();
                }
                return _featuredSkills;
            }
        }

        private List<string> _responsibilities;
        public List<string> Responsibilities
        {
            get
            {
                if (_responsibilities == null)
                {
                    _responsibilities = _base.ProjectResponsibilities
                        .OrderBy(r => r.Rank)
                        .Select(r => r.Description)
                        .ToList();
                }
                return _responsibilities;
            }
        }

        public DateTime LastWorked
        {
            get
            {
                if (_base.Contracts.Count == 0) return DateTime.MinValue;
                else return _base.Contracts.Max(c => c.EndDate);
            }
        }

        private string _monthSpan;
        public string MonthSpan
        {
            get
            {
                if (_monthSpan == null)
                {
                    DateTime? startDate = null, endDate = null;
                    if (_base.StartDate.HasValue && _base.EndDate.HasValue)
                    {
                        startDate = _base.StartDate.Value;
                        endDate = _base.EndDate.Value;
                    }
                    else if (_base.Contracts.Count > 0)
                    {
                        startDate = _base.Contracts.Min(c => c.StartDate);
                        endDate = _base.Contracts.Max(c => c.EndDate);
                    }
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        var format = "MMMM yyyy";

                        if (startDate.Value.Year == endDate.Value.Year && startDate.Value.Month == endDate.Value.Month)
                            _monthSpan = startDate.Value.ToString(format);
                        else if (endDate.Value > startDate.Value)
                            _monthSpan = string.Format("{0} - {1}", startDate.Value.ToString(format), endDate.Value.ToString(format));
                        else
                            _monthSpan = endDate.Value.ToString(format);
                    }
                    else
                        _monthSpan = "n/a";
                }
                return _monthSpan;
            }
        }

        private string _yearSpan;
        public string YearSpan
        {
            get
            {
                if (_yearSpan == null)
                {
                    DateTime? startDate = null, endDate = null;
                    if (_base.StartDate.HasValue && _base.EndDate.HasValue)
                    {
                        startDate = _base.StartDate.Value;
                        endDate = _base.EndDate.Value;
                    }
                    else if (_base.Contracts.Count > 0)
                    {
                        startDate = _base.Contracts.Min(c => c.StartDate);
                        endDate = _base.Contracts.Max(c => c.EndDate);
                    }
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        if (startDate.Value.Year == endDate.Value.Year)
                            _yearSpan = startDate.Value.Year.ToString();
                        else if (endDate.Value.Year > startDate.Value.Year)
                            _yearSpan = string.Format("{0} - {1}", startDate.Value.Year, endDate.Value.Year);
                        else
                            _yearSpan = endDate.Value.Year.ToString();
                    }
                    else
                        _yearSpan = "n/a";
                }
                return _yearSpan;
            }
        }

        public int YearLastWorked
        {
            get
            {
                if (_base.EndDate.HasValue) return _base.EndDate.Value.Year;
                else if (_base.Contracts.Count > 0) return _base.Contracts.Max(c => c.EndDate.Year);
                else return 0;
            }
        }
    }
}

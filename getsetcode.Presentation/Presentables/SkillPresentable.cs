using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Interface;
using getsetcode.Model;
using getsetcode.Helpers;
using getsetcode.Model.Enum;

namespace getsetcode.Presentation.Presentables
{
    public class SkillPresentable : ISkillPresentable
    {
        Skill _base;

        public SkillPresentable(Skill skill)
        {
            _base = skill;
        }

        #region Raw Properties

        public int SkillId { get { return _base.SkillId; } }

        public string Name { get { return _base.Name; } }

        public string ShortName { get { return _base.ShortName; } }

        public string Summary { get { return _base.Summary; } }

        public DateTime DateAcquired { get { return _base.DateAcquired; } }

        public string CurrentVersion { get { return _base.CurrentVersion; } }

        public bool IsCoreSkill { get { return _base.IsCoreSkill; } }

        public byte Rank { get { return _base.Rank; } }

        #endregion

        #region ILink Members

        public int LinkID { get { return _base.SkillId; } }

        public string LinkStringID { get { return _base.ShortName; } }

        public string LinkName { get { return _base.Name; } }

        public string LinkInfo { get { return _base.Summary; } }

        public string DetailAction { get { return "Detail"; } }

        public NavSection Section { get { return NavSection.Skills; } }

        #endregion

        #region Presentable Properties

        public SkillCategory Category
        {
            get
            {
                return _base.SkillCategory;
            }
        }

        public string Experience
        {
            get
            {
                int years = DateHelpers.YearsSince(_base.DateAcquired);
                if (years == 0) return "less than a year";
                else return string.Format("{0} year{1}", years, years != 1 ? "s" : "");
            }
        }

        public List<IProjectPresentable> AllProjects
        {
            get
            {
                return _base.ProjectSkills
                    .OrderBy(p => p.Rank)
                    .Select(p => new ProjectPresentable(p.Project))
                    .Cast<IProjectPresentable>()
                    .ToList();
            }
        }

        public List<IProjectPresentable> FeaturedProjects
        {
            get 
            {
                return AllProjects.Where(p => p.Featured).ToList();
            }
        }

        #endregion
    }
}

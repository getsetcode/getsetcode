using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Model;
using getsetcode.Presentation.Presentables;
using getsetcode.Web.Models.Shared;

namespace getsetcode.Web.Models.Skills
{
    public class SkillsListData : ExperienceData
    {
        public List<ISkillPresentable> Skills { get; set; }

        public List<SkillCategory> DistinctCategories
        {
            get
            {
                return Skills
                    .Select(s => s.Category)
                    .Distinct()
                    .OrderBy(c => c.Rank)
                    .ToList();
            }
        }

        public List<ISkillPresentable> CategorySkills(SkillCategory c)
        {
            return Skills
                .Where(s => s.Category.SkillCategoryId == c.SkillCategoryId)
                .OrderBy(s => s.Rank)
                .ToList();
        }
    }
}
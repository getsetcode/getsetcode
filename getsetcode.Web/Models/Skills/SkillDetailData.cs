using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Models.Skills
{
    public class SkillDetailData
    {
        public ISkillPresentable Skill { get; set; }

        public IProjectPresentable ReturnProject { get; set; }
    }
}
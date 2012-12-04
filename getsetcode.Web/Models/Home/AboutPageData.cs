using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Web.Models.Shared;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Models.Home
{
    public class AboutPageData
    {
        public MainSideBarData SideBarData { get; set; }

        public IEnumerable<ISkillPresentable> AllSkills { get; set; }
    }
}
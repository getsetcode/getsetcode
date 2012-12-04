using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Presentation.Presentables;
using getsetcode.Helpers;
using getsetcode.Model;

namespace getsetcode.Web.Models.Shared
{
    public class MainSideBarData : ExperienceData
    {
        public bool IsHomePage { get; set; }

        public IContractPresentable LatestContract { get; set; }

        public CurriculumVitae LatestCV { get; set; }
    }
}
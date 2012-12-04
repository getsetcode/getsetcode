using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Helpers;

namespace getsetcode.Web.Models.Shared
{
    public abstract class ExperienceData
    {
        public int YearsExperience
        {
            get { return DateHelpers.YearsSince(EmmaMorris.DotNetSkillsStartDate); }
        }
    }
}
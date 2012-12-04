using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Interface;
using getsetcode.Model;

namespace getsetcode.Presentation.Presentables
{
    public interface ISkillPresentable : ISkill, ILink
    {
        SkillCategory Category { get; }

        string Experience { get; }

        List<IProjectPresentable> AllProjects { get; }

        List<IProjectPresentable> FeaturedProjects { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Model.Interface
{
    public interface ISkill
    {
        int SkillId { get; }

        string Name { get; }

        string ShortName { get; }

        string Summary { get; }

        DateTime DateAcquired { get; }

        string CurrentVersion { get; }

        bool IsCoreSkill { get; }

        byte Rank { get; }
    }
}

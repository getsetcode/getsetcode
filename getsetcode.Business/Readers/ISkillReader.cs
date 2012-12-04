using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public interface ISkillReader
    {
        Skill Get(int id);

        Skill Get(string name);

        IEnumerable<Skill> List();
    }
}

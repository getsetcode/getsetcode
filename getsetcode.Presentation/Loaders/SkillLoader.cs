using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Business.Readers;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Presentation.Loaders
{
    public class SkillLoader : ISkillLoader
    {
        ISkillReader _reader;

        public SkillLoader(ISkillReader reader)
        {
            _reader = reader;
        }

        public ISkillPresentable GetPresentable(int id)
        {
            var skill = _reader.Get(id);

            if (skill == null) return null;
            else return new SkillPresentable(skill);
        }

        public ISkillPresentable GetPresentable(string name)
        {
            var skill = _reader.Get(name);

            if (skill == null) return null;
            else return new SkillPresentable(skill);
        }

        public IEnumerable<ISkillPresentable> ListPresentables()
        {
            foreach (var s in _reader.List())
            {
                yield return new SkillPresentable(s);
            }
        }
    }
}

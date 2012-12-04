using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public class SkillReader : ISkillReader
    {
        IContextAccessor _accessor;

        public SkillReader(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Skill Get(int id)
        {
            return get(id: id);
        }

        public Skill Get(string name)
        {
            return get(name: name);
        }

        private Skill get(int? id = null, string name = null)
        {
            if (string.IsNullOrEmpty(name) && !id.HasValue) throw new ArgumentException("One of name and id arguments must be non-null");
            using (var c = _accessor.Context())
            {
                return c.Context.Skills
                    .Where(s => (id.HasValue && s.SkillId == id.Value) || (!string.IsNullOrEmpty(name) && s.ShortName == name))
                    .Include(s => s.SkillCategory)
                    .Include(s => s.ProjectSkills)
                    .Include(s => s.ProjectSkills.Select(ps => ps.Project))
                    .Include(s => s.ProjectSkills.Select(ps => ps.Project.ThumbnailImage))
                    .Include(s => s.ProjectSkills.Select(ps => ps.Project.Contracts))
                    .SingleOrDefault();
            }
        }

        public IEnumerable<Skill> List()
        {
            using (var c = _accessor.Context())
            {
                return c.Context.Skills
                    .Include(s => s.SkillCategory)
                    .Include(s => s.ProjectSkills)
                    .Include(s => s.ProjectSkills.Select(ps => ps.Project))
                    .ToList();
            }
        }
    }
}

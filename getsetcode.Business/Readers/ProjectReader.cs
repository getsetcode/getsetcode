using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public class ProjectReader : IProjectReader
    {
        IContextAccessor _accessor;

        public ProjectReader(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Project Get(int id)
        {
            return get(id: id);
        }

        public Project Get(string name)
        {
            return get(name: name);
        }

        public IEnumerable<Project> List(bool? featured)
        {
            using (var c = _accessor.Context())
            {
                return c.Context.Projects
                    .Where(p => !featured.HasValue || p.Featured == featured.Value)
                    .Include(p => p.ProjectSkills)
                    .Include(p => p.ProjectSkills.Select(ps => ps.Skill))
                    .Include(p => p.Client)
                    .Include(p => p.Client.Logo)
                    .Include(p => p.Client.Logo.Thumbnail)
                    .Include(p => p.Contracts)
                    .Include(p => p.ThumbnailImage)
                    .ToList();
            }
        }

        private Project get(string name = null, int? id = null)
        {
            if (string.IsNullOrEmpty(name) && !id.HasValue) throw new ArgumentException("One of name and id arguments must be non-null");
            using (var c = _accessor.Context())
            {
                return c.Context.Projects
                    .Where(p => (id.HasValue && p.ProjectId == id.Value) || (!string.IsNullOrEmpty(name) && p.ShortName == name))
                    .Include(p => p.ProjectSkills)
                    .Include(p => p.ProjectSkills.Select(ps => ps.Skill))
                    .Include(p => p.Client)
                    .Include(p => p.Client.Logo)
                    .Include(p => p.Contracts)
                    .Include(p => p.ProjectImages)
                    .Include(p => p.ProjectImages.Select(i => i.Image))
                    .Include(p => p.ProjectImages.Select(i => i.Image.Thumbnail))
                    .Include(p => p.ProjectResponsibilities)
                    .SingleOrDefault();
            }
        }
    }
}

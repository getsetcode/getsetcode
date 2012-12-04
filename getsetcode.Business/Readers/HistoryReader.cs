using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public class HistoryReader : IHistoryReader
    {
        IContextAccessor _accessor;

        public HistoryReader(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public IEnumerable<HistoryItem> ListPresentables(DateTime? olderThan, int take)
        {
            using (var c = _accessor.Context())
            {
                return c.Context.History
                    .OrderByDescending(s => s.DateStamp)
                    .Where(s => !olderThan.HasValue || s.DateStamp < olderThan)
                    .Take(take)
                    // Project properties
                    .Include(s => s.Project)
                    .Include(s => s.Project.ProjectSkills)
                    .Include(s => s.Project.ProjectSkills.Select(ps => ps.Skill))
                    .Include(s => s.Project.Client)
                    .Include(s => s.Project.Client.Logo)
                    .Include(s => s.Project.Client.Logo.Thumbnail)
                    .Include(s => s.Project.Contracts)
                    .Include(s => s.Project.ThumbnailImage)
                    // Client properties
                    .Include(s => s.Client)
                    .Include(s => s.Client.Logo)
                    .Include(s => s.Client.Logo.Thumbnail)
                    .Include(s => s.Client.Projects)
                    .Include(s => s.Client.Projects.Select(p => p.ThumbnailImage))
                    .Include(s => s.Client.Projects.Select(p => p.Contracts))
                    // Testimonial propeties
                    .Include(s => s.Testimonial)
                    .Include(s => s.Testimonial.Person)
                    .Include(s => s.Testimonial.Person.Thumbnail)
                    .Include(s => s.Testimonial.Client)
                    .ToList();
            }
        }
    }
}

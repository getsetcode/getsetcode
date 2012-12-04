using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public class ClientReader : IClientReader
    {
        IContextAccessor _accessor;

        public ClientReader(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Client Get(int id)
        {
            return get(id: id);
        }

        public Client Get(string name)
        {
            return get(name: name);
        }

        public Client get(string name = null, int? id = null)
        {
            if (string.IsNullOrEmpty(name) && !id.HasValue) throw new ArgumentException("One of name and id arguments must be non-null");
            using (var c = _accessor.Context())
            {
                return c.Context.Clients
                    .Where(l => (id.HasValue && l.ClientId == id.Value) || (!string.IsNullOrEmpty(name) && l.ShortName == name))
                    .Include(l => l.Logo)
                    .Include(l => l.Logo.Thumbnail)
                    .Include(l => l.Projects)
                    .Include(l => l.Projects.Select(p => p.ThumbnailImage))
                    .Include(l => l.Projects.Select(p => p.Contracts))
                    .Include(l => l.Testimonials)
                    .Include(l => l.Testimonials.Select(t => t.Person))
                    .Include(l => l.Testimonials.Select(t => t.Person.Thumbnail))
                    .SingleOrDefault();
            }
        }
    }
}

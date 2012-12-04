using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public class TestimonialReader : ITestimonialReader
    {
        IContextAccessor _accessor;

        public TestimonialReader(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public IEnumerable<Testimonial> List()
        {
            using (var c = _accessor.Context())
            {
                return c.Context.Testimonials
                    .Include(t => t.Person)
                    .Include(t => t.Person.Thumbnail)
                    .Include(t => t.Client)
                    .ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Business.Readers;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Presentation.Loaders
{
    public class TestimonialLoader : ITestimonialLoader
    {
        ITestimonialReader _reader;

        public TestimonialLoader(ITestimonialReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<ITestimonialPresentable> ListPresentables()
        {
            foreach (var testimonial in _reader.List())
            {
                yield return new TestimonialPresentable(testimonial);
            }
        }
    }
}

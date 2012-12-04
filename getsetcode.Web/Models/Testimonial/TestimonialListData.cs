using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Models.Testimonial
{
    public class TestimonialListData
    {
        public List<ITestimonialPresentable> Testimonials { get; set; }
    }
}
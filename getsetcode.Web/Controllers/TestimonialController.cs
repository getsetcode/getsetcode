using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Web.Models.Testimonial;
using getsetcode.Presentation.Loaders;

namespace getsetcode.Web.Controllers
{
    public class TestimonialController : Controller
    {
        ITestimonialLoader _testimonialLoader;

        public TestimonialController(ITestimonialLoader testimonialLoader)
        {
            _testimonialLoader = testimonialLoader;
        }

        public ViewResult Index()
        {
            return View(new TestimonialListData()
            {
                Testimonials = _testimonialLoader.ListPresentables()
                    .OrderByDescending(t => t.Date)
                    .ToList()
            });
        }
    }
}

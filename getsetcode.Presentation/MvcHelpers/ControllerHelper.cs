using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Model.Enum;

namespace getsetcode.Presentation.MvcHelpers
{
    public static class ControllerHelper
    {
        public static string Controller(NavSection section)
        {
            switch (section)
            {
                case NavSection.CV: return "Cv";
                case NavSection.Contact: return "Contact";
                case NavSection.Home: return "Home";
                case NavSection.Portfolio: return "Portfolio";
                case NavSection.Skills: return "Skill";
                case NavSection.Testimonials: return "Testimonial";
                case NavSection.Blog: return "Blog";
                default: throw new Exception("Unhandled navigation route");
            }
        }

        public static string Text(NavSection section)
        {
            switch (section)
            {
                case NavSection.CV: return "CV";
                case NavSection.Contact: return "Contact";
                case NavSection.Home: return "Home";
                case NavSection.Portfolio: return "Portfolio";
                case NavSection.Skills: return "Skills";
                case NavSection.Testimonials: return "Testimonials";
                case NavSection.Blog: return "Blog";
                default: throw new Exception("Unhandled navigation route");
            }
        }
    }
}
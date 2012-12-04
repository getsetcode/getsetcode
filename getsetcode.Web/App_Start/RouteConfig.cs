using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using getsetcode.Web.Extensions.RouteCollectionExtensions;

namespace getsetcode.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("SkillsList", "skills", new { controller = "Skill", action = "Index" });
            routes.MapRoute("SkillDetail", "skill/{id}/{project}", new { controller = "Skill", action = "Detail", project = UrlParameter.Optional });
            routes.MapRoute("ProjectsList", "portfolio", new { controller = "Portfolio", action = "Index" });
            routes.MapRoute("TestimonialsList", "testimonials", new { controller = "Testimonial", action = "Index" });
            routes.MapRoute("ClientDetail", "portfolio/client/{id}", new { controller = "Portfolio", action = "ClientDetail" });
            routes.MapRoute("ProjectDetail", "portfolio/{id}/{client}", new { controller = "Portfolio", action = "Detail", client = UrlParameter.Optional });
            routes.MapRoute("ProjectDetailShorter", "p/{id}", new { controller = "Portfolio", action = "Detail" });
            routes.MapRoute("HistoryItems", "history/items/{items}/{last}", new { controller = "History", action = "History", last = UrlParameter.Optional });
            routes.MapRoute("Contact", "contact", new { controller = "Contact", action = "Index" });
            routes.MapRoute("RecentContacts", "contact/recent/cheekybackdoor", new { controller = "Contact", action = "Recent" });
            routes.MapRoute("ContactPost", "contact/send", new { controller = "Contact", action = "Send" });
            routes.MapRoute("CVPdf", "cv.pdf", new { controller = "Cv", action = "Pdf" });
            routes.MapRoute("CVDoc", "cv.doc", new { controller = "Cv", action = "Word" });
            routes.MapRoute("CVPdfPreview", "cv-preview.pdf", new { controller = "Cv", action = "PdfPreview" });
            routes.MapRoute("CV", "cv", new { controller = "Cv", action = "Index" });
            routes.MapRoute("BlogItems", "blog/items/{items}/{startIndex}", new { controller = "Blog", action = "Items" });
            routes.MapRoute("BlogList", "blog/{id}", new { controller = "Blog", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("AboutPage", "about", new { controller = "Home", action = "About" });
            routes.MapRoute("HomePage", "", new { controller = "Home", action = "Index" });
            
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
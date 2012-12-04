using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Web.Models.Shared;
using getsetcode.Presentation.Loaders;
using getsetcode.Web.Models.Home;
using getsetcode.Business.Readers;
using getsetcode.Web.Services;

namespace getsetcode.Web.Controllers
{
    public class HomeController : Controller
    {
        public enum Message { emailsent }

        readonly IContractLoader _contractLoader;
        readonly ICurriculumVitaeReader _cvReader;
        readonly IContactFormFactory _contactFormFactory;
        readonly ISkillLoader _skillLoader;

        public HomeController(IContractLoader contractLoader, ICurriculumVitaeReader cvReader, IContactFormFactory contactFormFactory, ISkillLoader skillLoader)
        {
            _contractLoader = contractLoader;
            _cvReader = cvReader;
            _contactFormFactory = contactFormFactory;
            _skillLoader = skillLoader;
        }

        public ActionResult Index(Message? msg)
        {
            return View("Index", new HomePageData()
            {
                Message = msg,
                ContactFormSubmission = _contactFormFactory.NewSubmission,
                SideBarData = new MainSideBarData()
                {
                    IsHomePage = true,
                    LatestContract = _contractLoader.LatestPresentable(),
                    LatestCV = _cvReader.GetLatest()
                }
            });
        }

        public ActionResult About()
        {
            return View("About", new AboutPageData()
            {
                SideBarData = new MainSideBarData(),
                AllSkills = _skillLoader.ListPresentables()
            });
        }
    }
}

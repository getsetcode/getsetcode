using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Model;
using getsetcode.Web.Models.Shared;
using getsetcode.Business.Writers;
using getsetcode.Business.Communicators;
using System.Net.Mail;
using getsetcode.Helpers;
using getsetcode.Web.Models.Contact;
using getsetcode.Presentation.Loaders;
using getsetcode.Business.Readers;
using getsetcode.Web.Services;

namespace getsetcode.Web.Controllers
{
    public class ContactController : Controller
    {
        IContactFormSubmissionWriter _contactFormSubmissionWriter;
        IContactFormSubmissionLoader _contactFormSubmissionLoader;
        IContractLoader _contractLoader;
        ICurriculumVitaeReader _cvReader;
        ISmtpService _smtpService;
        IContactFormFactory _contactFormFactory;
        ICookieHandler _cookieHandler;

        public ContactController(IContactFormSubmissionWriter contactFormSubmissionWriter, IContactFormSubmissionLoader contactFormSubmissionLoader, IContractLoader contractLoader, ICurriculumVitaeReader cvReader, ISmtpService smtpService, IContactFormFactory contactFormFactory, ICookieHandler cookieHandler)
        {
            _contactFormSubmissionWriter = contactFormSubmissionWriter;
            _contactFormSubmissionLoader = contactFormSubmissionLoader;
            _contractLoader = contractLoader;
            _cvReader = cvReader;
            _smtpService = smtpService;
            _contactFormFactory = contactFormFactory;
            _cookieHandler = cookieHandler;
        }

        public ActionResult Index()
        {
            return View(new ContactFormData()
                {
                    Submission = _contactFormFactory.NewSubmission,
                    MainSideBarData = mainSideBarData()
                });
        }

        // TODO: Implement 'load more' or paging for recent contacts and password protect
        public ViewResult Recent()
        {
            return View(new RecentContactsData()
            {
                Submissions = _contactFormSubmissionLoader.ListPresentables(null, 50).ToList()
            });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Send([Bind(Prefix = "Submission")] ContactFormSubmission s)
        {
            ContactFormData vd = new ContactFormData()
            {
                Submission = s
            };

            vd.Modal = false;
            vd.Errors = new List<string>();

            if (ModelState.IsValid)
            {
                s.DateStamp = DateTime.Now;
                bool emailSent = true;
                try
                {
                    _smtpService.SendToMe(new MailAddress(s.EmailAddress, s.Name), EmmaMorris.ContactMeSubject, s.Message);
                }
                catch
                {
                    emailSent = false;
                }
                s.EmailSent = emailSent;
                _contactFormSubmissionWriter.Save(s);

                _cookieHandler.LastContactFormSubmissionID = s.SubmissionId;

                return RedirectToAction("Index", "Home", new { msg = HomeController.Message.emailsent });
            }
            else
            {
                vd.Errors = ModelState.Values.Where(v => v.Errors.Any()).SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }

            vd.MainSideBarData = mainSideBarData();

            return View("Index", vd);
        }

        private MainSideBarData mainSideBarData()
        {
            return new MainSideBarData()
            {
                IsHomePage = false,
                LatestContract = _contractLoader.LatestPresentable(),
                LatestCV = _cvReader.GetLatest()
            };
        }
    }
}

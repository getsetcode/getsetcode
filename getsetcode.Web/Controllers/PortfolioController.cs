using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Web.Models.Portfolio;
using getsetcode.Helpers;
using getsetcode.Presentation.Loaders;
using getsetcode.Presentation.Presentables;
using getsetcode.Web.Models.Client;

namespace getsetcode.Web.Controllers
{
    public class PortfolioController : Controller
    {
        IProjectLoader _projectLoader;
        IClientLoader _clientLoader;

        public PortfolioController(IProjectLoader projectLoader, IClientLoader clientLoader)
        {
            _projectLoader = projectLoader;
            _clientLoader = clientLoader;
        }

        public ViewResult Index()
        {
            return View(new ProjectListData()
            {
                Projects = _projectLoader.ListFeaturedPresentables()
                    .OrderByDescending(p => p.YearLastWorked)
                    .ToList()
            });
        }

        public ActionResult Detail(string id, int? client)
        {
            IProjectPresentable project = null;
            int intID;
            if (int.TryParse(id, out intID))
                project = _projectLoader.GetPresentable(intID);
            else if (!string.IsNullOrEmpty(id)) 
                project = _projectLoader.GetPresentable(id);

            IClientPresentable returnClient = null;
            if (project != null && client.HasValue && project.Client.ClientId == client.Value)
            {
                returnClient = project.Client;
            }

            return View("Detail", new ProjectDetailData()
            {
                Project = project,
                ReturnClient = returnClient
            });
        }

        public ActionResult ClientDetail(string id)
        {
            IClientPresentable client = null;
            int intID;
            if (int.TryParse(id, out intID))
                client = _clientLoader.GetPresentable(intID);
            else if (!string.IsNullOrEmpty(id))
                client = _clientLoader.GetPresentable(id);

            return View("ClientDetail", new ClientDetailData()
            {
                Client = client
            });
        }
    }
}

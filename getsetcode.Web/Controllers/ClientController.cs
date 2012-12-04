using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Web.Models.Client;
using getsetcode.Presentation.Loaders;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Controllers
{
    public class ClientController : Controller
    {
        private IClientLoader _clientLoader;

        public ClientController(IClientLoader clientLoader)
        {
            _clientLoader = clientLoader;
        }

    }
}

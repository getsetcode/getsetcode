using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Models.Client
{
    public class ClientDetailData
    {
        public IClientPresentable Client { get; set; }
    }
}
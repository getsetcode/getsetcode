using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Models.Portfolio
{
    public class ProjectDetailData
    {
        public IProjectPresentable Project { get; set; }

        public IClientPresentable ReturnClient { get; set; }
    }
}
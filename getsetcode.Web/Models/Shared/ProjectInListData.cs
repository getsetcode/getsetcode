using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Models.Shared
{
    public class ProjectInListData
    {
        public IProjectPresentable Project { get; set; }

        public bool LineAfter { get; set; }

        public IClientPresentable ReturnClient { get; set; }
    }
}
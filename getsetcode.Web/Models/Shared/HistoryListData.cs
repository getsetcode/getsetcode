using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Models.Shared
{
    public class HistoryListData
    {
        public bool InitialLoad { get; set; }

        public List<IHistoryItemPresentable> HistoryItems { get; set; }
    }
}
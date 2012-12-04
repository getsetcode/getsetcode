using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Web.Extensions.ControllerExtensions;
using getsetcode.Helpers;
using getsetcode.Web.Models.Shared;
using getsetcode.Presentation.Loaders;

namespace getsetcode.Web.Controllers
{
    public class HistoryController : Controller
    {
        IHistoryLoader _historyLoader;

        public HistoryController(IHistoryLoader historyLoader)
        {
            _historyLoader = historyLoader;
        }

        [HttpGet]
        public JsonResult History(int items, string last)
        {
            //Server.UrlEncode(Model[h].DateStamp.ToString("yyyy/MM/dd HH:mm:ss"))
            DateTime? olderThan = null;
            try
            {
                if (!string.IsNullOrEmpty(last))
                    olderThan = DateTime.Parse(Server.UrlDecode(last));
            }
            catch
            { // Oh well
            }

            var history = _historyLoader.ListPresentables(olderThan, items + 1).ToList();

            bool moreAvailable = false;
            if (history.Count > items)
            {
                moreAvailable = true;
                history = history.Take(items).ToList();
            }

            DateTime? newLast = null;
            if (history.Any()) newLast = history.Min(h => h.DateStamp);

            return new JsonResult
            {
                Data = new
                {
                    Items = history.Count,
                    MoreAvailable = moreAvailable,
                    Last = newLast.HasValue ? Server.UrlEncode(newLast.Value.ToString("yyyy/MM/dd HH:mm:ss")) : null,
                    Html = this.RenderPartialView(
                        "History/HistoryItems",
                        new HistoryListData()
                        {
                            HistoryItems = history,
                            InitialLoad = !olderThan.HasValue
                        })
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json; charset=utf-8"
            };
        }

    }
}

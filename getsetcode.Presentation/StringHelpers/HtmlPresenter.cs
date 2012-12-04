using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Enum;
using getsetcode.Presentation.MvcHelpers;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web;
using System.Web.Routing;
using getsetcode.Presentation.Presentables;
using getsetcode.Model.Interface;

namespace getsetcode.Presentation.StringHelpers
{
    public static class HtmlPresenter
    {
        private class ObjRef
        {
            public ILink Obj { get; set; }
            public string Text { get; set; }
        }

        private enum Step { Content, ID, Text }

        private static string _skillRegex = @"\[skill\=([^\]]+)\]([^\]]+)\[/skill\]";
        private static string _clientRegex = @"\[client\=([^\]]+)\]([^\]]+)\[/client\]";
        private static string _projectRegex = @"\[project\=([^\]]+)\]([^\]]+)\[/project\]";

        public static string HideInContentLinks(string str)
        {
            str = formatInContentLinks(str, _skillRegex, null, new List<ILink>());
            str = formatInContentLinks(str, _clientRegex, null, new List<ILink>());
            str = formatInContentLinks(str, _projectRegex, null, new List<ILink>());
            return str;
        }

        public static string FormatInContentLinks(this HtmlHelper html, string str, List<ISkillPresentable> skills = null, List<IClientPresentable> clients = null, List<IProjectPresentable> projects = null, int? returnProjectID = null, int? returnClientID = null)
        {
            if (skills != null)
                str = formatInContentLinks(str, _skillRegex, html, skills.Cast<ILink>(), returnProjectID, returnClientID);

            if (clients != null)
                str = formatInContentLinks(str, _clientRegex, html, clients.Cast<ILink>());

            if (projects != null)
                str = formatInContentLinks(str, _projectRegex, html, projects.Cast<ILink>());

            return str;
        }

        public static string formatInContentLinks(string str, string regex, HtmlHelper html, IEnumerable<ILink> targets, int? returnProjectID = null, int? returnClientID = null)
        {
            var match = Regex.Match(str, regex);

            bool atStart = (match.Success && match.Index == 0);

            var regexSplit = Regex.Split(str, regex);

            var sb = new StringBuilder();
            var or = new ObjRef();
            Step nextStep;

            if (atStart) nextStep = Step.ID;
            else nextStep = Step.Content;

            for (var i = 0; i < regexSplit.Length; i++)
            {
                switch (nextStep)
                {
                    case Step.Content:
                        sb.Append(regexSplit[i]);
                        nextStep = Step.ID;
                        or = new ObjRef();
                        break;
                    case Step.ID:
                        int temp;
                        if (int.TryParse(regexSplit[i], out temp) && targets.Any(s => s.LinkID == temp))
                        {
                            or.Obj = targets.Single(s => s.LinkID == temp);
                        }
                        nextStep = Step.Text;
                        break;
                    case Step.Text:
                        or.Text = regexSplit[i];
                        nextStep = Step.Content;
                        if (or.Obj != null && html != null)
                        {
                            sb.Append(html.DetailLink(or.Obj, tip: TipType.After, linkText: string.IsNullOrEmpty(or.Text) ? or.Obj.LinkName : or.Text, returnProjectID: returnProjectID, returnClientID: returnClientID));
                        }
                        else
                        {
                            sb.Append(or.Text);
                        }
                        break;
                }
            }

            return sb.ToString();
        }

        //public static string FormatEntityLinks(this HtmlHelper html, string str, int? projectID = null)
        //{
        //    return formatEntityLinks(str, html, projectID);
        //}

        //private static string formatEntityLinks(string str, HtmlHelper html = null, int? projectID = null)
        //{
        //    var htmlVersion = (html != null);
        //    str = doSkillsReplace(html, str, htmlVersion, projectID);
        //    str = doClientReplace(html, str, htmlVersion, projectID);
        //    str = doProjectReplace(html, str, htmlVersion, projectID);
        //    return str;
        //}

        //private static string doSkillsReplace(HtmlHelper html, string original, bool htmlVersion, int? projectID = null)
        //{
        //    return doReplace(html, original, _skillRegex, NavSection.Skills, "Detail", htmlVersion, projectID);
        //}

        //private static string doClientReplace(HtmlHelper html, string original, bool htmlVersion, int? projectID = null)
        //{
        //    return doReplace(html, original, _clientRegex, NavSection.Portfolio, "ClientDetail", htmlVersion, projectID);
        //}

        //private static string doProjectReplace(HtmlHelper html, string original, bool htmlVersion, int? projectID = null)
        //{
        //    return doReplace(html, original, _projectRegex, NavSection.Portfolio, "Detail", htmlVersion, projectID);
        //}

        //private static string doReplace(HtmlHelper html, string original, string regex, NavSection section, string action, bool htmlVersion, int? projectID = null)
        //{
        //    var exp = new Regex(regex);
        //    string r;
        //    if (htmlVersion)
        //    {
        //        var rv = new RouteValueDictionary(new { id = "$1" });
        //        if (projectID.HasValue)
        //        {
        //            rv.Add("project", projectID.Value);
        //        }
        //        r = HttpUtility.UrlDecode(html.ActionLink("$2", action, ControllerHelper.Controller(section), rv, null).ToString());
        //    }
        //    else
        //        r = "$2";
        //    return exp.Replace(original, r);
        //}
    }
}

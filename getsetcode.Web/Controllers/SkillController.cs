using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Web.Models.Skills;
using getsetcode.Presentation.Loaders;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Web.Controllers
{
    public class SkillController : Controller
    {
        ISkillLoader _skillLoader;

        public SkillController(ISkillLoader skillLoader)
        {
            _skillLoader = skillLoader;
        }

        public ActionResult Index()
        {
            return View(new SkillsListData()
                {
                    Skills = _skillLoader.ListPresentables()
                        .OrderByDescending(s => s.IsCoreSkill)
                        .ThenBy(s => s.Rank)
                        .ToList()
                });
        }

        public ActionResult Detail(string id, int? project)
        {
            var s = _skillLoader.GetPresentable(id);

            IProjectPresentable returnProject = null;
            if (project.HasValue && s.AllProjects.Any(p => p.ProjectId == project.Value))
            {
                returnProject = s.AllProjects.Single(p => p.ProjectId == project.Value);
            }

            return View("Detail", new SkillDetailData()
            {
                Skill = s,
                ReturnProject = returnProject
            });
        }
    }
}

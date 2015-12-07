namespace HRMS.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CMS.DocumentEngine.Types;

    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            //Getting all ProjectSections
            var projects = ProjectsProvider.GetProjects();
            return View(projects);
        }
    }
}
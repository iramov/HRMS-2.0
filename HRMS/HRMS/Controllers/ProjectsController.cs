namespace HRMS.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CMS.DocumentEngine.Types;
    using System.Net;
    using HRMS.Models.ViewModels;

    public class ProjectsController : Controller
    {
        // GET: All projects sections
        public ActionResult Index()
        {
            //Getting all ProjectSections
            var projects = ProjectsProvider.GetProjects();
            return View(projects);
        }

        // GET: All projects
        public ActionResult AllProjects(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Get all sections
            Projects section = ProjectsProvider.GetProjects((int)id, "en-us", "HRMS");
            if (section == null)
            {
                return HttpNotFound();
            }
            // Declare list of projects
            List<Project> projects = new List<Project>();

            var children = section.Children;
            // Getting all projects inside sections
            foreach (var child in children)
            {
                Project obj = ProjectProvider.GetProject(child.NodeID, "en-us", "HRMS");
                projects.Add(obj);
            }
            return View(projects);
        }

        //GET: Details of current project
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Get all sections
            Project section = ProjectProvider.GetProject((int)id, "en-us", "HRMS");
            if (section == null)
            {
                return HttpNotFound();
            }
            // Declare list of projects
            List<Project> projects = new List<Project>();

            var children = section.Children;
            // Getting all projects inside sections
            foreach (var child in children)
            {
                Project obj = ProjectProvider.GetProject(child.NodeID, "en-us", "HRMS");
                projects.Add(obj);
            }

            ProjectViewModel viewModel = new ProjectViewModel();


            return View(projects);
        }
    }
}
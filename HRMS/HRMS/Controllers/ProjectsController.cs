﻿namespace HRMS.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CMS.DocumentEngine.Types;
    using System.Net;
    using HRMS.Models.ViewModels;
    using CMS.Search;
    using CMS.DataEngine;

    public class ProjectsController : Controller
    {
        public ActionResult Index(string sortOrder)
        {
            //Getting all ProjectSections
            var projects = ProjectsProvider.GetProjects();

            // Order by different criteria
            projects = OrderSections(sortOrder, projects);

            //var test = ProjectsProvider.GetProjects()
            return View(projects);
        }

        // GET: All projects
        public ActionResult AllProjects(int? id, string sortOrder)
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

            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.DeliverySort = String.IsNullOrEmpty(sortOrder) ? "delivery" : "";

            switch (sortOrder)
            {
                case "name":
                    var orderByName = projects.OrderBy(p => p.Fields.Name);
                    return View(orderByName);
                case "delivery":
                    var orderByDelivery = projects.OrderBy(p => p.Fields.Delivery);
                    return View(orderByDelivery);
                default:
                    var orderDefault = projects.OrderBy(p => p.Fields.ID);
                    return View(orderDefault);
            }
        }

        //GET: Details of current project
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Get project
            Project project = ProjectProvider.GetProject((int)id, "en-us", "HRMS");
            if (project == null)
            {
                return HttpNotFound();
            }
            // Declare list of teams
            List<Teams> teams = new List<Teams>();

            var children = project.Children;
            // Get all teams included in this project
            foreach (var child in children)
            {
                Teams obj = TeamsProvider.GetTeams(child.NodeID, "en-us", "HRMS");
                teams.Add(obj);
            }


            // Declare and fill a new set of projects and teams
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.Project = project;
            viewModel.Teams = teams;

            return View(viewModel);
        }

        // Order projects sections by name
        private CMS.DocumentEngine.DocumentQuery<Projects> OrderSections(string sortOrder, CMS.DocumentEngine.DocumentQuery<Projects> projects)
        {
            ViewBag.ProjectSectionSort = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            switch (sortOrder)
            {
                case "name":
                    projects = ProjectsProvider.GetProjects().OrderBy("ProjectsName");
                    break;
                default:
                    projects = ProjectsProvider.GetProjects().OrderBy("ProjectsID");
                    break;
            }
            return projects;
        }

        // Order projects by name or delivery
        
    }
}
using CMS.DocumentEngine.Types;
using HRMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        public ActionResult Index()
        {
            var sections = TeamsProvider.GetTeams();
            return View(sections);
        }

        //GET: Teams/Details/2
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teams section = TeamsProvider.GetTeams((int)id, "en-us", "HRMS");
            if (section == null)
            {
                return HttpNotFound();
            }
            List<Team> teams = new List<Team>();
            var children = section.Children;
            foreach (var child in children)
            {
                Team obj = TeamProvider.GetTeam(child.NodeID, "en-us", "HRMS");
                teams.Add(obj);
            }
            return View(teams);
        }

        //GET: Teams/TeamDetails/2
        public ActionResult TeamDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = TeamProvider.GetTeam((int)id, "en-us", "HRMS");
            if (team == null)
            {
                return HttpNotFound();
            }
            List<Employee> employees = new List<Employee>();
            var children = team.Children;
            foreach (var child in children)
            {
                Employee obj = EmployeeProvider.GetEmployee(child.NodeID, "en-us", "HRMS");
                employees.Add(obj);
            }

            TeamViewModel viewModel = new TeamViewModel();
            viewModel.Team = team;
            viewModel.Members = employees;
            return View(viewModel);
        }
    }
}
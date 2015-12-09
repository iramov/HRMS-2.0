using CMS.DocumentEngine.Types;
using HRMS.Helpers;
using HRMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class TeamsController : BaseController
    {
        /// <summary>
        /// Print table containing all team pages in the site
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string sortOrder)
        {
            List<string> viewBagFields = SortHelper.GetTeamsSortViewBagFields(ref sortOrder);
            ViewBag.NameSortParam = viewBagFields[0];
            ViewBag.DeliverySortParam = viewBagFields[1];
            var teams = TeamProvider.GetTeams();
            SortHelper.SortByColumn(teams, sortOrder);
            return View(teams);
        }

        /// <summary>
        /// Returns table containing all team sections
        /// in the site
        /// </summary>
        /// <returns></returns>
        
        public ActionResult AllSections()
        {
            var sections = TeamsProvider.GetTeams();
            return View(sections);
        }

        //GET: Teams/Details/2
        public ActionResult SectionDetails(int? id)
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
        public ActionResult TeamDetails(int? id, string sortOrder)
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
            TeamViewModel viewModel = new TeamViewModel();
            viewModel.Team = team;
            var children = team.Children;
            if (children.Count != 0)
            {
                CMS.DocumentEngine.DocumentQuery<Employee> employeesQuery = new CMS.DocumentEngine.DocumentQuery<Employee>();
                foreach (var child in children)
                {
                    var employee = EmployeeProvider.GetEmployee(child.NodeID, "en-us", "HRMS");
                    employeesQuery.Union(employee);
                }
                viewModel.Members = SortEmployees(employeesQuery, ref sortOrder);
            }
            else
            {
                viewModel.Members = new List<Employee>();
            }
            return View(viewModel);
        }
    }
}
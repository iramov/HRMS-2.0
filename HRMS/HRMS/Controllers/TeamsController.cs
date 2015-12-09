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
        public ActionResult Index(string sortOrder, string filterWord)
        {
            List<string> viewBagFields = SortHelper.GetTeamsSortViewBagFields(ref sortOrder);
            ViewBag.NameSortParam = viewBagFields[0];
            ViewBag.DeliverySortParam = viewBagFields[1];
            var teams = TeamProvider.GetTeams();
            SortHelper.SortByColumn(teams, sortOrder);

            if (filterWord != String.Empty)
            {
                SortHelper.SortByColumn(teams, sortOrder);
                var viewModel = FilterTeams(filterWord, teams);
                return View(viewModel);
            }

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

        /// <summary>
        /// Filtering the teams by entered search word
        /// </summary>
        /// <param name="search">The word that you want to filter the teams by</param>
        /// <param name="team">Collection of teams that will be filtered</param>
        /// <returns>The input collection filtered</returns>
        private IOrderedQueryable<Team> FilterTeams(string search, IOrderedQueryable<Team> team)
        {
            if (!String.IsNullOrEmpty(search))
            {
                team = team.Where(e => e.Fields.Name.Contains(search)
                    || e.Fields.Delivery.ToString().Contains(search))
                    .OrderBy(e => e.Fields.ID);
            }
            return team;
        }
    }
}
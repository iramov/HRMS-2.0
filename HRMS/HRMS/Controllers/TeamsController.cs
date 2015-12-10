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
            var teams = TeamProvider.GetTeams();
            var teamsList = SortTeams(teams, sortOrder);

            if (filterWord != String.Empty)
            {
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

        public ActionResult SectionDetails(int? id, string sortOrder, int? projectId)
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
            if (projectId != null)
            {
                ViewBag.ParentId = projectId;
            }
            TeamsSectionViewModel viewModel = new TeamsSectionViewModel
            {
                Section = section,
                Children = new List<Team>()
            };
            if (section.Children.Any())
            {
                var teamsQuery = TeamProvider.GetTeams()
                    .Where("NodeParentID", CMS.DataEngine.QueryOperator.Equals, section.NodeID);
                viewModel.Children = SortTeams(teamsQuery, sortOrder);
            }
            return View(viewModel);
        }

        //GET: Teams/TeamDetails/2
        public ActionResult TeamDetails(int? id, string sortOrder, int? projectId)
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
            if (projectId != null)
            {
                ViewBag.ProjectId = projectId;
            }
            TeamViewModel viewModel = new TeamViewModel
            {
                Team = team,
                Members = new List<Employee>()
            };
            if (team.Children.Any())
            {
                var employeesQuery = EmployeeProvider.GetEmployees().Where("NodeParentID", CMS.DataEngine.QueryOperator.Equals, team.NodeID);
                viewModel.Members = SortEmployees(employeesQuery, sortOrder);
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
                    || e.Fields.Delivery.ToString().Contains(search)
                    || e.Fields.AvailablePositions.Contains(search))
                    .OrderBy(e => e.Fields.ID);
            }
            return team;
        }
    }
}
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
            var teams = TeamProvider.GetTeams();
            return View(SortTeams(teams, ref sortOrder));
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

        public ActionResult SectionDetails(int? id, string sortOrder)
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
            TeamsSectionViewModel viewModel = new TeamsSectionViewModel
            {
                Section = section,
                Children = new List<Team>()
            };
            if (section.Children.Any())
            {
                var teamsQuery = TeamProvider.GetTeams().Where("NodeParentID", CMS.DataEngine.QueryOperator.Equals, section.NodeID);
                viewModel.Children = SortTeams(teamsQuery, ref sortOrder);
            }
            return View(viewModel);
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
            TeamViewModel viewModel = new TeamViewModel
            {
                Team = team,
                Members = new List<Employee>()
            };
            if (team.Children.Any())
            {
                var employeesQuery = EmployeeProvider.GetEmployees().Where("NodeParentID", CMS.DataEngine.QueryOperator.Equals, team.NodeID);
                viewModel.Members = SortEmployees(employeesQuery, ref sortOrder);
            }
            return View(viewModel);
        }
    }
}
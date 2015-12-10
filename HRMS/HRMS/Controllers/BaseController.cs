using CMS.DocumentEngine.Types;
using HRMS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public abstract class BaseController : Controller
    {
        public List<Employee> SortEmployees(CMS.DocumentEngine.DocumentQuery<Employee> query, string sortOrder)
        {
            List<string> viewBagFields = SortHelper.GetEmployeesSortViewBagFields(sortOrder);
            ViewBag.FirstNameSortParam = viewBagFields[0];
            ViewBag.LastNameSortParam = viewBagFields[1];
            ViewBag.PositionSortParam = viewBagFields[2];
            SortHelper.SortByColumn(query, sortOrder);
            return query.ToList();
        }
        public List<Team> SortTeams(CMS.DocumentEngine.DocumentQuery<Team> query, string sortOrder)
        {
            List<string> viewBagFields = SortHelper.GetTeamsSortViewBagFields(sortOrder);
            ViewBag.NameSortParam = viewBagFields[0];
            ViewBag.DeliverySortParam = viewBagFields[1];
            SortHelper.SortByColumn(query, sortOrder);
            return query.ToList();
        }
        public List<Project> SortProjects(CMS.DocumentEngine.DocumentQuery<Project> query, string sortOrder)
        {
            List<string> viewBagFields = SortHelper.GetProjectsSortViewBagFields(sortOrder);
            ViewBag.ProjectNameSortParam = viewBagFields[0];
            ViewBag.DeliverySortParam = viewBagFields[1];
            SortHelper.SortByColumn(query, sortOrder);
            return query.ToList();
        }
    }
}
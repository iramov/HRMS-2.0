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
        public List<Employee> SortEmployees(CMS.DocumentEngine.DocumentQuery<Employee> query, ref string sortOrder)
        {
            List<string> viewBagFields = SortHelper.GetEmployeesSortViewBagFields(ref sortOrder);
            ViewBag.FirstNameSortParam = viewBagFields[0];
            ViewBag.LastNameSortParam = viewBagFields[1];
            ViewBag.PositionSortParam = viewBagFields[2];
            SortHelper.SortByColumn(query, sortOrder);
            return query.ToList();
        }
    }
}
namespace HRMS.Controllers
{
    using CMS.DocumentEngine.Types;
    using HRMS.Models.ViewModels;
    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            //Getting all the sections with employees who are not assigned into teams
            var employeeSections = FreeEmployeesProvider.GetFreeEmployees();
            //employeeSections = null;
            return View(employeeSections);
        }

        public ActionResult SectionDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sectionEmployees = FreeEmployeesProvider.GetFreeEmployees(id.Value, "en-Us", "HRMS").FirstOrDefault();
            if (sectionEmployees == null)
            {
                return HttpNotFound();
            }
            var viewModel = new EmployeeSectionsWithChilds();
            var allChildren = new List<Employee>();
            var employees = sectionEmployees.Children;
            viewModel.Section = sectionEmployees;
            if (employees != null)
            {
                foreach (var child in employees)
                {
                    var childToAdd = EmployeeProvider.GetEmployee(child.NodeID, "en-Us", "HRMS");
                    allChildren.Add(childToAdd);
                }
            }

            viewModel.Children.AddRange(allChildren);
            return View(viewModel);
        }

        public ActionResult EmployeeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = EmployeeProvider.GetEmployee(id.Value, "en-Us", "HRMS").FirstOrDefault();
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

    }
}
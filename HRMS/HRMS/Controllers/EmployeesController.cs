namespace HRMS.Controllers
{
    using CMS.DocumentEngine.Types;
    using HRMS.Models.ViewModels;
    using System;
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
            var first = employeeSections.First();
            
            //var viewModels = new List<EmployeeSectionsWithChilds>();
            //foreach (var section in employeeSections)
            //{
            //    var viewModel = new EmployeeSectionsWithChilds();
            //    viewModel.Section = section;
            //    var employees = section.Children;
            //    foreach (var child in employees)
            //    {
            //        var childToAdd = EmployeeProvider.GetEmployee(child.NodeID, "en-Us", "HRMS");
            //        viewModel.Children.Add(childToAdd);
            //    }
            //}


            return View(employeeSections);
        }

        public ActionResult SectionDetails(int id)
        {
            var sectionEmployees = FreeEmployeesProvider.GetFreeEmployees(id, "en-Us", "HRMS").FirstOrDefault();
            var viewModel = new EmployeeSectionsWithChilds();
            var allChildren = new List<Employee>();
            var employees = sectionEmployees.Children;
            viewModel.Section = sectionEmployees;
            foreach (var child in employees)
            {
                var childToAdd = EmployeeProvider.GetEmployee(child.NodeID, "en-Us", "HRMS");
                allChildren.Add(childToAdd);
            }
            viewModel.Children.AddRange(allChildren);
            return View(viewModel);
        }

        public ActionResult EmployeeDetails(int id)
        {
            var employee = EmployeeProvider.GetEmployee(id, "en-Us", "HRMS").FirstOrDefault();

            return View(employee);
        }

        /// <summary>
        /// Showing all the employees who are assigned into teams
        /// </summary>
        /// <returns>View with all the employees</returns>
        public ActionResult TeamMembers()
        {
            var teamsSections = TeamsProvider.GetTeams();

            return View();
        }
    }
}
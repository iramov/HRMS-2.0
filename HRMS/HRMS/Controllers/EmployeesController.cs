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
    using Helpers;

    public class EmployeesController : Controller
    public class EmployeesController : BaseController
    {
        // GET: Employees
<<<<<<< HEAD
        public ActionResult Index(string filterWord)
        {
            //Getting all employees in the site and printing them as a table
            var allEmployees = EmployeeProvider.GetEmployees();

            var viewModel = FilterEmployees(filterWord, allEmployees);

            return View(viewModel);
=======
        public ActionResult Index(string sortOrder)
        {
            //Getting all employees in the site and printing them as a table
            var allEmployees = EmployeeProvider.GetEmployees();
            //SortHelper.SortByColumn(allEmployees, sortOrder);
            SortEmployees(allEmployees, ref sortOrder);
            return View(allEmployees);
>>>>>>> refs/remotes/origin/master
        }

        /// <summary>
        /// Finding section of employees by input param NodeId, getting its children and printing them in a table
        /// </summary>
        /// <param name="id">The NodeId of a Section with employees</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SectionDetails(int? id, string sortOrder)
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
            //ViewModel to store the data of the Parent Section and its children Employees
            var viewModel = new EmployeeSectionsWithChilds();
            CMS.DocumentEngine.DocumentQuery<Employee> allChildren = new CMS.DocumentEngine.DocumentQuery<Employee>();
            //Getting all the children on a section, saving them in a collection and printing them with they parent section name in a table
            var sectionChildren = sectionEmployees.Children;
            viewModel.Section = sectionEmployees;
            if (sectionChildren != null)
            {
                foreach (var child in sectionChildren)
                {
                    var childToAdd = EmployeeProvider.GetEmployee(child.NodeID, "en-Us", "HRMS");
                    allChildren.Union(childToAdd);
                }
            }
            viewModel.Children.AddRange(SortEmployees(allChildren, ref sortOrder));
            return View(viewModel);
        }

        /// <summary>
        /// Finding employee by input param id and printing all its fields
        /// </summary>
        /// <param name="id">The NodeId for the searched employee</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmployeeDetails(int? id,int? teamSectionId, int? employeeSectionId)
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
            if (teamSectionId != null)
            {
                ViewBag.ParentId = teamSectionId;
            }
            if (employeeSectionId != null)
            {
                ViewBag.EmployeeSectionId = employeeSectionId;
            }
            return View(employee);
        }

        /// <summary>
        /// Printing all the sections with free employees
        /// </summary>
        /// <returns>List of sections with employees</returns>
        [HttpGet]
        public ActionResult AllSections()
        {
            //Getting all the sections with employees who are not assigned into teams
            var employeeSections = FreeEmployeesProvider.GetFreeEmployees();
            //employeeSections = null;
            return View(employeeSections);
        }

        /// <summary>
        /// Filtering the employees by entered search word
        /// </summary>
        /// <param name="search">The word that you want to filter the employees by</param>
        /// <param name="employees">Collection of employees that will be filtered</param>
        /// <returns>The input collection filtered</returns>
        private static IOrderedQueryable<Employee> FilterEmployees(string search, IOrderedQueryable<Employee> employees)
        {
            if (!String.IsNullOrEmpty(search))
            {
                employees = employees.Where(e => e.Fields.FirstName.Contains(search)
                    || e.Fields.Position.ToString().Contains(search)
                    || e.Fields.LastName.Contains(search)
                    || e.Fields.Email.Contains(search))
                    .OrderBy(e => e.Fields.ID);
            }
            return employees;
        }

    }
}
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
            //Getting all employees in the site and printing them as a table
            var allEmployees = EmployeeProvider.GetEmployees();
            return View(allEmployees);
        }

        /// <summary>
        /// Finding section of employees by input param NodeId, getting its children and printing them in a table
        /// </summary>
        /// <param name="id">The NodeId of a Section with employees</param>
        /// <returns></returns>
        [HttpGet]
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
            //ViewModel to store the data of the Parent Section and its children Employees
            var viewModel = new EmployeeSectionsWithChilds();
            var allChildren = new List<Employee>();
            //Getting all the children on a section, saving them in a collection and printing them with they parent section name in a table
            var sectionChildren = sectionEmployees.Children;
            viewModel.Section = sectionEmployees;
            if (sectionChildren != null)
            {
                foreach (var child in sectionChildren)
                {
                    var childToAdd = EmployeeProvider.GetEmployee(child.NodeID, "en-Us", "HRMS");
                    allChildren.Add(childToAdd);
                }
            }

            viewModel.Children.AddRange(allChildren);
            return View(viewModel);
        }

        /// <summary>
        /// Finding employee by input param id and printing all its fields
        /// </summary>
        /// <param name="id">The NodeId for the searched employee</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmployeeDetails(int? id,int? parentId, int? employeeSectionId)
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
            if (parentId != null)
            {
                ViewBag.ParentId = parentId;
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

    }
}
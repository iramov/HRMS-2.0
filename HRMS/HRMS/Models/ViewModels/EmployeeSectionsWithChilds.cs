using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.DocumentEngine.Types;

namespace HRMS.Models.ViewModels
{
    public class EmployeeSectionsWithChilds
    {
        public EmployeeSectionsWithChilds()
        {
            this.Children = new List<Employee>();
        }

        public FreeEmployees Section { get; set; }

        public List<Employee> Children { get; set; }
    }
}
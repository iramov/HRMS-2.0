using CMS.DocumentEngine.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models.ViewModels
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public List<Employee> Members { get; set; }
    }
}
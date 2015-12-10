using CMS.DocumentEngine.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models.ViewModels
{
    public class ProjectsSectionViewModel
    {
        public Projects Section { get; set; }
        public List<Project> Children { get; set; }
    }
}
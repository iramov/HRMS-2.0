using CMS.DocumentEngine.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models.ViewModels
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }

        public List<Teams> Teams { get; set; }
    }
}
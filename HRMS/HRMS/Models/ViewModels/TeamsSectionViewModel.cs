using CMS.DocumentEngine.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models.ViewModels
{
    public class TeamsSectionViewModel
    {
        public Teams Section { get; set; }
        public List<Team> Children { get; set; }
    }
}
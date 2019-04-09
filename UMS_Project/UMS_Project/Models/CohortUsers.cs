using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS_Project.Models
{
    public class CohortUsers
    {
        public IEnumerable<Cohort> Cohorts { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
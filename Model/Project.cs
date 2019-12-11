using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageProject.Model
{
    public class Project
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string MemberName { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public int BugList { set; get; }
        public int BugUav { set; get; }
        public double PlanCost { set; get; }
        public double ActualCost { set; get; }
        public int CssScore { set; get; }
        public string Description { set; get; }
        public Boolean Status { get; set; }
    }
}

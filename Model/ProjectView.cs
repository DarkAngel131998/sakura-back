using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageProject.Model
{
    public class ProjectView
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Member { get; set; }
        public string Description { set; get; }
        
        public DateTime Startdate { set; get; }
        public DateTime Finishdate { set; get; }
        public int Bugtest { set; get; }
        public int Buguat { set; get; }
        public double Pcost { set; get; }
        public double Acost { set; get; }
        public int Cssscore { set; get; }
        
        public bool Status { get; set; }
    }
    public class RequestModel
    {
        [Range(1, 999)]
        public int index { get; set; }
        [Range(1, 100)]
        public int size { get; set; }
        public string searchText { get; set; }
    }

    
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public Paging Paging { get; set; }
    }

    public class Paging
    {
        public int index { get; set; }
        public int size { get; set; }
        public long count { get; set; }
    }
}

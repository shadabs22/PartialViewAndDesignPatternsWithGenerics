using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartialViewDemo.Models
{
    public class MyDemoModel
    {
    }
    public class department
    {
        public string DepartmentName { get; set; }
        public string DepartmentRule { get; set; }
        public string AdminComment { get; set; }
    }

    public class Company
    {
        public List<department> department { get; set; }
    }
}
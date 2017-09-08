using PartialViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewDemo.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}


        public ActionResult Index()
        {
            var model = new Company();
            model.department = GetDepartmentList();
            return View(model);
        }

        public List<department> GetDepartmentList()
        {
            var model = new List<department>();
            for (var count = 1; count <= 5; count++)
            {
                var data = new department();
                data.DepartmentName = "IT " + count;
                data.DepartmentRule = "Rule " + count;
                data.AdminComment = "Admin omment " + count;
                model.Add(data);
            }
            return model;
        }

        public PartialViewResult ShowPartailView()
        {
            //return PartialView("_MyView");
             return PartialView("_MyPartialview", GetDepartmentList());
        }
    }
}
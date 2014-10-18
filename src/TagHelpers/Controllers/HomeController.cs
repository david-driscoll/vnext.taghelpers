using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;

namespace TagHelpers.Controllers
{
    public class HomeModel
    {
        public string Name { get; set; }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeModel() { Name = "Tag Helper?" });
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
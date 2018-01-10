using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineWebApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WineWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            Wine test1 = new Wine();
            test1.testList.Add(test1.TestMethod());
            test1.testList.Add(test1.TestMethod());
            test1.testList.Add(test1.TestMethod());
            Wine test2 = new Wine();
            test2.testList.Add(test2.TestMethod());
            test2.testList.Add(test2.TestMethod());
            test2.testList.Add(test2.TestMethod());
            Wine test3 = new Wine();
            test3.testList.Add(test3.TestMethod());
            test3.testList.Add(test3.TestMethod());
            test3.testList.Add(test3.TestMethod());
            List<Wine> testWineList = new List<Wine> { test1, test2, test3 };

            ViewData["Name"] = "Ariel";

            return View(test1);
        }

        [HttpPost]
        public IActionResult Index(Wine w)
        {
            return RedirectToAction("TestView", new {w});
        }

        public IActionResult TestView(Wine w)
        {
            return View(w);
        }
    }
}

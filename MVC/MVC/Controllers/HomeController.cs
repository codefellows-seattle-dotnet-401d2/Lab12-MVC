using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{

    public class HomeController : Controller
    {

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(string name, string price, string points)
        {
            return RedirectToAction("Results", new {name, price, points});
        }

        [HttpGet]

        public IActionResult Results(string name, string price, string points)
        {
            ViewBag.Name = name;
            List<Wine> wineList = Wine.FilterWineList(price, points);
            return View(wineList);
        }
    }
}

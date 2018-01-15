using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Wine> wineList = Wine.GetWineList();
            IEnumerable<Wine> WineList = wineList.Select(w => w);
            return View(WineList.Skip(1));
        }

        [HttpPost]
        public IActionResult Index(string name, string price, string points)
        {
            return RedirectToAction("Results", new { name, price, points });
        }

        public IActionResult Results(string name, string price, string points)
        {
            List<Wine> wineList = Wine.GetWineList();
            IEnumerable<Wine> filteredWineList = wineList.Where(w => w.Price == price && w.Points == points);
            ViewData["Name"] = name;
            return View(filteredWineList);
        }
    }
}

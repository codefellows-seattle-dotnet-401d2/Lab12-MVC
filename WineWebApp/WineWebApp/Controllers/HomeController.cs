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

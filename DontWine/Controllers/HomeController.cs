using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DontWine.Models;

/// <summary>
/// SPECIAL THANKS TO LUAY FOR HELPING ME THROUGH THIS PAIN IN THE BUTT ASSIGNMENT
/// </summary>

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DontWine.Models
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // I think this thing is useless. I don't have time to try without it though.
        [HttpPost]
        public IActionResult Index(int price, int points)
        {
            return RedirectToAction("Results", new { price, points });
        }

        [HttpGet]
        public IActionResult Results(Wine wine)
        {
            List<Wine> winelist = Wine.GetWineList();
            if (wine.Price != "0")
            {
                winelist = winelist.Where(w => w.Price == wine.Price).ToList();
            }
            if (wine.Points != "0")
            {
                winelist = winelist.Where(w => w.Points == wine.Points).ToList();
            }

            return View(winelist);
        }
    }
}

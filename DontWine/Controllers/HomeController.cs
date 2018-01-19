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
            List<Wine> WineList = Wine.GetWineList();
            return View(WineList);
        }

        // I think this thing is useless. I don't have time to try without it though.
        [HttpPost]
        public IActionResult Index(int price, int points)
        {
            string price_ = price.ToString();
            string points_ = points.ToString();
            return RedirectToAction("Results", new {price_, points_ });
        }

        [HttpGet]
        public IActionResult Results(string price, string points)
        {
            List<Wine> Winelist = Wine.GetWineList();

            if (price != "0")
            {
                Winelist = Winelist.Where(wine_ => wine_.Price == price).ToList();
            }
            if (points != "0")
            {
                Winelist = Winelist.Where(wine_ => wine_.Points == points).ToList();
            }
            return View(Winelist);
        }
    }
}

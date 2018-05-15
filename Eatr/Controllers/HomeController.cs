using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eatr.Models;

namespace Eatr.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            YelpApi repos = YelpApi.Recommend();
            return View(repos);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
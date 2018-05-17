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
            return View();
        }

        public IActionResult Result()
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

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(YelpApi newSearch)
        {
            newSearch.Send();
            return RedirectToAction("Result");
        }

        public IActionResult Param1()
        {
            return View();
        }
        public IActionResult Param2()
        {
            return View();
        }
        public IActionResult Param3()
        {
            return View();
        }
        public IActionResult Param4()
        {
            return View();
        }
        public IActionResult Param5()
        {
            return View();
        }
        public IActionResult Param6()
        {
            return View();
        }
        public IActionResult Param7()
        {
            return View();
        }
        public IActionResult Param8()
        {
            return View();
        }


    }
}
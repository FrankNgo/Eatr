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

        //public IActionResult Eatr()
        //{
        //    YelpApi repos = YelpApi.Recommend();
        //    return View(repos);
        //}

        public IActionResult Eatr()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Eatr(YelpApi newSearch)
        {
            newSearch.SearchParams();
            return RedirectToAction("Eatr");
        }
    }
}
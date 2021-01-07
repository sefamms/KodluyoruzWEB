using KodluyoruzWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["class_1"] = "bg-success";
            TempData["class_2"] = "bg-danger";
            TempData["class_3"] = "bg-warning";

            var current = Directory.GetCurrentDirectory();
            ViewBag.current = current;

            return View();
            //return View("~/Views/Product/Index.cshtml");
        }

        

        public IActionResult Login(Login p)
        {

           
            if (ModelState.IsValid)
            {
                if (p.Username == "deneme" && p.Password=="123")
                {

                    return RedirectToAction("Index");
                }
            }

            return View(p);
        }

    }
}

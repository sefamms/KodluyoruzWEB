using KodluyoruzWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            Product product = new Product
            {
                Id=1,
                Name="Bilgisayar",
                ImageUrl="1.jpg",
                Price=1000
            };
            return View(product);
        }
    }
}


using KodluyoruzWEB.Models;
using KodluyoruzWEB.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IUserService userService,IEmailService emailService)
        {
            this._userService = userService;
            this._emailService = emailService;
        }

        [Route("~/")]
        public IActionResult Index()
        {
            //UserEmailOptions options = new UserEmailOptions
            //{
            //    toEmails=new List<string>() { "test@gmail.com"},
            //    PlaceHolders=new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{UserName}}","Nitish")
            //    }
            //};
            //await _emailService.SendTestEmail(options);

            //  var userId = _userService.GetUserId();
            // var isLoggedIn = _userService.IsAuthenticated();

            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult ContactUs()
        {
            return View();
        }
        
    }
}

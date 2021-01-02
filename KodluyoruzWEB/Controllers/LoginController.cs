using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Controllers
{
    public class LoginController : Controller
    {
        private string Email = "sefa@gmail.com";
        private string Password = "123";


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string password)
        {

            return SigIn(email, password) ? RedirectToAction("Index", "Home") : RedirectToAction("Index","Login");
        }
        private bool SigIn(string _email,string password)
        {
            bool result;
            result = CheckEmail(_email) && CheckPassword(password) ? true : false;

            return result;
        }


        private bool CheckEmail(string _email)
        {
            if (_email != Email)
            {
                return false;
            }
            return true;
        }
        private bool CheckPassword(string _password)
        {
            if (_password != Password)
            {
                return false;
            }
            return true;
        }

    }
}

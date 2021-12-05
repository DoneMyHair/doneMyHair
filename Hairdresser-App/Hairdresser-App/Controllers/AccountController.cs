using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdresser_App.Controllers
{
    public class AccountController : Controller
    {
        [Route("~/Account/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("~/Account/Signup")]
        public IActionResult Signup()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Models.SELECT;

namespace WebApp.Controllers
{
    public class SigninController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/Signin/SigninPage.cshtml");
        }

        [HttpPost]
        public ActionResult Validate(string username, string password)
        {
            if (ValidateUser.Validating(username, password))
            {
                return RedirectPermanent("/MainPage/Index/");
            }

            ViewBag.Message = "Incorrect Username or Password";

            return View("~/Views/Signin/SigninPage.cshtml");
        }
    }
}
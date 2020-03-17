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
        public JsonResult Validate(SigninUserModel user)
        {
            if (ValidateUser.Validating(user))
            {
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.DenyGet);
        }
    }
}
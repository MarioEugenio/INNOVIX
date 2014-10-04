using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace INNOVIX_RFIX.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                return RedirectToAction("Index", "Home/Index");

            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Init()
        {
            return View();
        }
    }
}

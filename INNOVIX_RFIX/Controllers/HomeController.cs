using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace INNOVIX_RFIX.Controllers
{
     [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.baseUrl = Request.Url.ToString().Replace(Request.Path, "");
            ViewBag.userCurrent = User.Identity.Name;

            return View();
        }
    }
}

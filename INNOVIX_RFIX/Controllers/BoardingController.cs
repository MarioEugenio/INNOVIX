using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INNOVIX_RFIX.Controllers
{
     [Authorize]
    public class BoardingController : ControllerBase
    {
        //
        // GET: /Boarding/

        public ActionResult List()
        {
            ViewBag.role = Session["role"];

            return View();
        }

    }
}

using Innovix.Base.Domain.Entity;
using Innovix.Base.Domain.Service;
using Innovix.Base.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INNOVIX_RFIX.Controllers
{
     [Authorize]
    public class ReportSealsController : ControllerBase
    {
        public ViewResult List()
        {
            return View();
        }

        public ViewResult Item()
        {
            return View();
        } 

        public JsonResult Get(int Id)
        {
            return this.returnJson("{}");
        }

        public JsonResult GetAll(int limit, int offset)
        {
            return this.returnJson("{}");
        }

        public JsonResult GetReportItem(string search, int limit, int offset)
        {
            return this.returnJson("{}");
        }

        public JsonResult GetAllHistory(int Id, int limit, int offset)
        {
            return this.returnJson("{}");
        }
    }
}

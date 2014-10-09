using Innovix.Base.Domain.Service;
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
         private ITbLoteService serviceLote;
        private ITbLogLoteService service;

        public BoardingController(ITbLogLoteService service, ITbLoteService serviceLote)
        {
            this.serviceLote = serviceLote;
            this.service = service;
        }

        public ActionResult List()
        {

            ViewBag.role = Session["role"];

            return View();
        }


        public JsonResult Get(int Id)
        {
            var result = this.serviceLote
               .Pesquisar(x => x.Id == Id)
               .Select(x => new
               {
                   Id = x.Id,
                   noDesc = x.noDesc,
                   origin = x.tbLocalidade.noNome,
                   destiny = x.tbLocalidadeDest.noNome,
                   route = x.tbRota.noNome,
                   //status = x.tbItem.FirstOrDefault().tbStatus.noDesc
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.serviceLote
                .Listar()
                .Select(x => new
                {
                    Id = x.Id,
                    noDesc = x.noDesc,
                    origin = x.tbLocalidade.noNome,
                    destiny = x.tbLocalidadeDest.noNome,
                    route = x.tbRota.noNome,
                    //status = x.tbItem.FirstOrDefault().tbStatus.noDesc
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }
    }
}

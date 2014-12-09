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
        private ITbSacoService serviceSaco;
        private ITbLogSacoService service;
        private ITbItemService serviceItem;
        private ITbLacreService serviceLacre;

        public ReportSealsController(ITbLogSacoService service, ITbSacoService serviceSaco, ITbItemService serviceItem, ITbLacreService serviceLacre)
        {
            this.serviceItem = serviceItem;
            this.service = service;
            this.serviceSaco = serviceSaco;
            this.serviceLacre = serviceLacre;
        }

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
            var result = this.serviceItem
               .GetItemLacre(Id)
               .Select(x => new
               {
                   awb = x.AWB,
                   epc = x.EPC,
                   lacre = x.Lacre,
                   route = x.Rota,
                   status = x.Status,
                   location = x.UltimaLocalidade,
                   dtAtualizacao = x.UltimaAtualizacao.ToString("d/MM/yyyy"),
                   operador = x.UltimoOperador

               });

            return this.returnJson(result);
        }

        public JsonResult GetReportItem(searchSeals search, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceLacre
                .GetLacres()
                .Select(x => new
                {
                    Id =  x.ID,
                    awb = x.Lacre,
                    origin = x.Origem.ToString(),
                    destiny = x.Destino.ToString(),
                    dtAtualizacao = x.UltimaAtualizacao.ToString("d/MM/yyyy"),
                    objDate = x.UltimaAtualizacao,
                      lacre = x.Lacre,
                    status = x.Status
                });

            if (search.cod != null)
                result = result.Where(x => x.awb.ToLower().Contains(search.cod.ToLower()));

            if (search.dtAtualizacao.Year != 1)
                result = result.Where(x => x.objDate.Date >= search.dtAtualizacao.Date && x.objDate.Date <= search.dtAtualizacao.Date);

            if (search.origem != null)
                result = result.Where(x => x.origin.Equals(search.origem));

            if (search.destino != null)
                result = result.Where(x => x.destiny.Equals(search.destino));

            if (order == "ASC")
            {
                result = result.OrderBy(x => x.GetType().GetProperty(predicate).GetValue(x, null));
            }
            else
            {
                result = result.OrderByDescending(x => x.GetType().GetProperty(predicate).GetValue(x, null));
            }

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count(), result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.serviceLacre
                 .GetLacres()
                .Select(x => new
                {
                    Id = x.ID,
                    awb = x.Lacre,
                    origin = x.Origem,
                    destiny = x.Destino,
                    dtAtualizacao = x.UltimaAtualizacao.ToString("d/MM/yyyy"),
                    objDate = x.UltimaAtualizacao,
                    lacre = x.Lacre,
                    status = x.Status
                });

            if (order == "ASC")
            {
                result = result.OrderBy(x => x.GetType().GetProperty(predicate).GetValue(x, null));
            }
            else
            {
                result = result.OrderByDescending(x => x.GetType().GetProperty(predicate).GetValue(x, null));
            }

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count(), result);
        }

        public JsonResult GetAllHistory(int Id, int limit, int offset, string predicate, string order)
        {

            var result = this.serviceItem.GetItemLacre(Id)
               .Select(x => new
               {
                   awb = x.AWB,
                   lacre = x.Lacre,
                   epc = x.EPC,
                   dtAtualizacao = x.UltimaAtualizacao.ToString("d/MM/yyyy"),
                   UltimaLocalidade = x.UltimaLocalidade,
                   route = x.Rota,
                   status = x.Status,
                   operador = x.UltimoOperador
               });

            if (order == "ASC")
            {
                result = result.OrderBy(x => x.GetType().GetProperty(predicate).GetValue(x, null));
            }
            else
            {
                result = result.OrderByDescending(x => x.GetType().GetProperty(predicate).GetValue(x, null));
            }

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count(), result);
        }
    }

     public class searchSeals
     {
         public string cod { get; set; }
         public string destino { get; set; }
         public string origem { get; set; }
         public DateTime dtAtualizacao { get; set; }
     }
}

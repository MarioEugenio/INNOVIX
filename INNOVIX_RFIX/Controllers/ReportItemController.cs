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
    public class ReportItemController : ControllerBase
    {
        private ITbLogEpcService service;
        private ITbItemService serviceItem;
        private ITbLacreService serviceLacre;

        public ReportItemController(ITbLogEpcService service, ITbItemService serviceItem, ITbLacreService serviceLacre)
        {
            this.service = service;
            this.serviceItem = serviceItem;
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
               .GetItemDetalhes(Id)
               .Select(x => new
               {
                   awb = x.AWB,
                   origin = x.Origem,
                   destiny = x.Destino,
                   route = x.Rota,
                   status = x.Status,
                   dtAtualizacao = x.DataCadastro.ToString("d/MM/yyyy"),
                   lacre = x.Lacre,
                   embarque = x.Embarque,
                   dtCadastro = x.DataCadastro.ToString("d/MM/yyyy"),
                   epc = x.EPC
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.serviceItem
                .GetItems()
                .Select(x => new {
                    Id = x.ID,
                    awb = x.AWB,
                    origin = x.Origem,
                    destiny = x.Destino,
                    route = x.Rota,
                    status = x.Status,
                    dtAtualizacao = x.UltimaAtualizacao.ToString("d/MM/yyyy")
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

        public JsonResult GetReportItem(searchItem search, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceItem
                .GetItems()
                .Select(x => new
                {
                    Id = x.ID,
                    awb = x.AWB,
                    origin = x.Origem,
                    destiny = x.Destino,
                    route = x.Rota,
                    status = x.Status,
                    dtAtualizacao = x.UltimaAtualizacao.ToString("d/MM/yyyy"),
                    objData = x.UltimaAtualizacao
                });

            if (search.awb != null)
                result = result.Where(x => x.awb.ToLower().Contains(search.awb.ToLower()));

            if (search.dtAtualizacao.Year != 1)
                result = result.Where(x => x.objData.Date >= search.dtAtualizacao.Date && x.objData.Date <= search.dtAtualizacao.Date);

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

        public JsonResult GetAllHistory(int Id, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceItem.GetItemHistorico(Id)
               .Select(x => new
               {
                   local = x.Localidade,
                   dtAtualizacao = x.Data.ToString("d/MM/yyyy"),
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

    public class searchItem {
        public string awb { get; set; }
        public string destino { get; set; }
        public string origem { get; set; }
        public DateTime dtAtualizacao { get; set; }
    }
}

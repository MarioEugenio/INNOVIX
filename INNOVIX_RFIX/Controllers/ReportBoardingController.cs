using Innovix.Base.Domain.Entity;
using Innovix.Base.Domain.Service;
using Innovix.Base.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Text;

namespace INNOVIX_RFIX.Controllers
{
     [Authorize]
    public class ReportBoardingController : ControllerBase
    {
         private ITbLoteService serviceLote;
        private ITbLacreService service;
        private ITbLogEpcService serviceEpc;
        private ITbItemService serviceItem;
        private ITbSacoService serviceSaco;

        public ReportBoardingController(ITbLacreService service, ITbLoteService serviceLote, ITbItemService serviceItem, ITbLogEpcService serviceEpc, ITbSacoService serviceSaco)
        {
            this.serviceEpc = serviceEpc;
            this.serviceItem = serviceItem;
            this.serviceLote = serviceLote;
            this.serviceSaco = serviceSaco;
            this.service = service;
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
            var result = this.serviceLote
               .GetLoteDetalhes(Id)
               .Select(x => new
               {
                   embarque = x.Embarque,
                   origin = x.Origem,
                   destiny = x.Destino,
                   dtCadastro = x.DataCadastro.ToString("dd/MM/yyyy"),
                   dtAtualizacao = x.UltimaAtualizacao.ToString("dd/MM/yyyy"),
                   status = x.Status,
                   lacre = x.Lacre,
                   totalItens = x.TotalItens,
                   totalItensEntregues = x.TotalItensEntregues
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.serviceLote
                .GetLotes()
                .Select(x => new
                {
                    Id = x.ID,
                    noDesc = x.Embarque,
                    origin = x.Origem,
                    destiny = x.Destino,
                    ultimaLocalidade = x.UltimaLocalidade,
                    dtAtualizacao = x.UltimaAtualizacao.ToString("dd/MM/yyyy"),
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

        public JsonResult GetReportItem(searchBoarding search, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceLote
                .GetLotes()
                .Select(x => new
                {
                    Id = x.ID,
                    noDesc = x.Embarque,
                    origin = x.Origem,
                    destiny = x.Destino,
                    dtAtualizacao = x.UltimaAtualizacao.ToString("dd/MM/yyyy"),
                    objDtAtualizacao = x.UltimaAtualizacao,
                    status = x.Status
                });

            if (search.cod != null)
                result = result.Where(x => x.noDesc.Contains(search.cod));

            if (search.dtAtualizacao.Year != 1)
                result = result.Where(x => x.objDtAtualizacao.Date >= search.dtAtualizacao.Date && x.objDtAtualizacao.Date <= search.dtAtualizacao.Date);

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

        public JsonResult GetAllItem(int Id, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceItem.GetItemLote(Id)
               .Select(x => new
               {
                   awb = x.AWB,
                   epc = x.EPC,
                   lacre = x.Lacre,
                   ultimaAtualizacao = x.UltimaAtualizacao.ToString("d/MM/yyyy"),
                   route = x.Rota,
                   ultimaLocalidade = x.UltimaLocalidade,
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

        public JsonResult GetAllSeals(int Id, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceItem.GetItemHistoricoLote(Id)
               .Select(x => new
               {
                   localidade = x.Localidade,
                   operador = x.Operador,
                   data = x.Data.ToString("d/MM/yyyy"),
                   totalItensLidos = x.TotalItensLidos
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

     public class searchBoarding
     {
         public string cod { get; set; }
         public string destino { get; set; }
         public string origem { get; set; }
         public DateTime dtAtualizacao { get; set; }
     }
}

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

        public ReportSealsController(ITbLogSacoService service, ITbSacoService serviceSaco)
        {
            this.service = service;
            this.serviceSaco = serviceSaco;
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
            var result = this.service
               .Pesquisar(x => x.Id == Id)
               .Select(x => new
               {
                   Id = x.Id,
                   awb = x.codBarras,
                   origin = x.tbEquipamento.tbLocalidade.noNome,
                   destiny = x.tbLocalidade.noNome,
                   //route = null,
                   status = x.tbOperacao.noDesc,
                   dtAtualizacao = x.dthLog

               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.serviceSaco
                .Listar()
                .Select(x => new
                {
                    Id =  x.Id,
                    awb = (x.tbLacre != null) ? x.tbLacre.indCodbarras : null,
                    origin = (x.tbLote != null)? x.tbLote.tbLocalidade.noCidade : null,
                    destiny = (x.tbLote != null)? x.tbLote.tbLocalidadeDest.noCidade : null,
                      dtAtualizacao = x.dthCriacao.ToString("dd/MM/yyyy"),
                      lacre = (x.tbLacre != null)? x.tbLacre.Id : 0
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetReportItem(searchSeals search, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceSaco
                 .Pesquisar(x => (x.Id == search.cod)
                   || (x.dthCriacao.Date >= search.dtAtualizacao.Date && x.dthCriacao.Date <= search.dtAtualizacao.Date)
                   || (x.tbLote.tbLocalidade.Id == search.origem)
                   || (x.tbLote.tbLocalidadeDest.Id == search.destino))
                .Select(x => new
                {
                    Id = x.Id,
                    awb = (x.tbLacre != null) ? x.tbLacre.indCodbarras : null,
                    origin = (x.tbLote != null) ? x.tbLote.tbLocalidade.noCidade : null,
                    destiny = (x.tbLote != null) ? x.tbLote.tbLocalidadeDest.noCidade : null,
                    dtAtualizacao = x.dthCriacao.ToString("dd/MM/yyyy"),
                    lacre = (x.tbLacre != null) ? x.tbLacre.Id : 0
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetAllHistory(int Id, int limit, int offset, string predicate, string order)
        {
            return this.returnJson("{}");
        }
    }

     public class searchSeals
     {
         public int cod { get; set; }
         public int destino { get; set; }
         public int origem { get; set; }
         public DateTime dtAtualizacao { get; set; }
     }
}

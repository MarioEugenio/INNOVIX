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
    public class ReportBoardingController : ControllerBase
    {
         private ITbLoteService serviceLote;
        private ITbLogLoteService service;
        private ITbLogSacoService serviceSaco;

        public ReportBoardingController(ITbLogLoteService service, ITbLoteService serviceLote, ITbLogSacoService serviceSaco)
        {
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
               .Pesquisar(x => x.Id == Id)
               .Select(x => new
               {
                   Id = x.Id,
                   embarque = x.noDesc,
                   origin = x.tbLocalidade.noNome,
                   destiny = x.tbLocalidadeDest.noNome,
                   route = x.tbRota.noNome,
                   dtCadastro = x.dthCriacao.ToString("dd/MM/yyyy"),
                   dtAtualizacao = x.tbItem.LastOrDefault().dthCriacao.ToString("dd/MM/yyyy"),
                   //status = x
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
                    noDesc = x.Id,
                    origin = x.tbLocalidade.noNome,
                    destiny = x.tbLocalidadeDest.noNome,
                    route = x.tbRota.noNome,
                    dtAtualizacao = x.dthCriacao.ToString("dd/MM/yyyy")
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetReportItem(searchBoarding search, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceLote
                 .Pesquisar(x => (x.Id == search.cod)
                   || (x.dthCriacao.Date >= search.dtAtualizacao.Date && x.dthCriacao.Date <= search.dtAtualizacao.Date)
                   || (x.tbLocalidade.Id == search.origem)
                   || (x.tbLocalidadeDest.Id == search.destino))
                .Select(x => new
                {
                    Id = x.Id,
                    noDesc = x.Id,
                    origin = x.tbLocalidade.noNome,
                    destiny = x.tbLocalidadeDest.noNome,
                    route = x.tbRota.noNome,
                    dtAtualizacao = x.dthCriacao.ToString("dd/MM/yyyy")
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetAllItem(int Id, int limit, int offset, string predicate, string order)
        {
            var objEpc = this.serviceLote.ObterPorId(Id);

            var result = this.service
               .Pesquisar(x => x.noNome.Equals(objEpc.noDesc))
               .Select(x => new
               {
                   Id = x.Id,
                   awb = x.tbEquipamento.tbLogsaco.FirstOrDefault().codBarras,
                   origin = x.tbEquipamento.tbLocalidade.noCidade,
                   destiny = x.tbLocalidade.noCidade,
                   //route = x.,
                   dtAtualizacao = x.dthLog.ToString("dd/MM/yyyy"),
                   responsavel = x.tbLocalidade.noResponsavel,
                   status = x.tbOperacao.noDesc

               });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetAllSeals(int Id, int limit, int offset, string predicate, string order)
        {
            var objEpc = this.serviceLote.ObterPorId(Id);

            var result = this.serviceSaco
              .Listar()
              .Select(x => new
              {
                  Id = x.Id,
                  awb = x.tbEquipamento.tbLogsaco.FirstOrDefault().codBarras,
                  origin = x.tbEquipamento.tbLocalidade.noCidade,
                  destiny = x.tbLocalidade.noCidade,
                  dtAtualizacao = x.dthLog.ToString("dd/MM/yyyy"),
                  responsavel = x.tbLocalidade.noResponsavel,
                  status = x.tbOperacao.noDesc

              });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }
    }

     public class searchBoarding
     {
         public int cod { get; set; }
         public int destino { get; set; }
         public int origem { get; set; }
         public DateTime dtAtualizacao { get; set; }
     }
}

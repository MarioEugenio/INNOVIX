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

        public ReportItemController(ITbLogEpcService service, ITbItemService serviceItem)
        {
            this.service = service;
            this.serviceItem = serviceItem;
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
                   awb = x.tbEquipamento.tbLogsaco.FirstOrDefault().codBarras,
                   origin = x.tbEquipamento.tbLocalidade.noNome,
                   destiny = x.tbLocalidade.noNome,
                   //route = x.tbLocalidade.,
                   status = x.tbOperacao.noDesc,
                   dtAtualizacao = x.dthLog.ToString("d/MM/yyyy"),
                   responsavel = x.tbLocalidade.noResponsavel,
                   // lacre = x.tbEquipamento.tbLogsaco.SingleOrDefault().
                   embarque = x.tbEquipamento.tbLoglote.FirstOrDefault().tbLocalidade.noNome,
                   dtCadastro = x.dthLog.ToString("d/MM/yyyy"),
                   epc = x.codEpc

               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.serviceItem
                .Listar() 
                .Select(x => new {
                    Id = x.Id,
                    awb = x.codBarras,
                    origin = (x.tbLocalidade != null) ? x.tbLocalidade.noNome : null,
                    destiny = (x.tbLocalidadeDestino != null) ? x.tbLocalidadeDestino.noNome : null,
                    route = (x.tbLote != null)? x.tbLote.tbRota.noNome : null,
                    status = (x.tbStatus != null)? x.tbStatus.noDesc : null,
                    dtAtualizacao = x.dthCriacao.ToString("d/MM/yyyy")
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetReportItem(searchItem search, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceItem
               .Pesquisar(x => (x.codBarras == search.awb) 
                   || (x.dthCriacao.Date >= search.dtAtualizacao.Date && x.dthCriacao.Date <= search.dtAtualizacao.Date) 
                   || (x.tbLocalidade.Id == search.origem)
                   || (x.tbLocalidadeDestino.Id == search.destino))
               .Select(x => new
               {
                   Id = x.Id,
                   awb = x.codBarras,
                   origin = (x.tbLocalidade != null) ? x.tbLocalidade.noNome : null,
                   destiny = (x.tbLocalidadeDestino != null) ? x.tbLocalidadeDestino.noNome : null,
                   route = (x.tbLote != null) ? x.tbLote.tbRota.noNome : null,
                   status = (x.tbStatus != null) ? x.tbStatus.noDesc : null,
                   dtAtualizacao = x.dthCriacao.ToString("d/MM/yyyy")
               });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetAllHistory(int Id, int limit, int offset, string predicate, string order)
        {
            var objEpc = this.serviceItem.ObterPorId(Id);

            var result = this.service
               .Pesquisar(x => x.codEpc == objEpc.codBarras)
               .Select(x => new
               {
                   Id = x.Id,
                   awb = x.tbEquipamento.tbLogsaco.FirstOrDefault().codBarras,
                   local = x.tbEquipamento.tbLocalidade.noNome,
                   equipamento = x.tbEquipamento.noEquipamento,
                   acao = x.tbOperacao.noDesc,
                   dtAtualizacao = x.dthLog.ToString("d/MM/yyyy"),
                   responsavel = x.tbLocalidade.noResponsavel

               });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }
    }

    public class searchItem {
        public string awb { get; set; }
        public int destino { get; set; }
        public int origem { get; set; }
        public DateTime dtAtualizacao { get; set; }
    }
}

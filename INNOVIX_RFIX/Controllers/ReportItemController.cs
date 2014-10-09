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
                    dtAtualizacao = x.dthCriacao.ToString("d/MM/yyyy")
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetReportItem(string search, int limit, int offset, string predicate, string order)
        {
            return this.returnJson("{}");
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
}

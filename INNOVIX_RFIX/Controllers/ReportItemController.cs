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

        public ReportItemController(ITbLogEpcService service)
        {
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
            var result = this.service
               .Pesquisar(x => x.Id == Id)
               .Select(x => new
               {
                   Id = x.Id,
                   awb = x.codEpc,
                   origin = x.tbEquipamento.tbLocalidade.noNome,
                   destiny = x.tbLocalidade.noNome,
                   //route = x.tbLocalidade.,
                   status = x.tbOperacao.noDesc,
                   dtAtualizacao = x.dthLog.ToString("d/MM/yyyy")

               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset)
        {
            var result = this.service
                .Listar()
                .Select(x => new
                {
                    Id = x.Id,
                    awb = x.codEpc,
                    origin = x.tbEquipamento.tbLocalidade.noNome,
                    destiny = x.tbLocalidade.noNome,
                    //route = x.tbLocalidade.,
                    status = x.tbOperacao.noDesc,
                    dtAtualizacao = x.dthLog.ToString("d/MM/yyyy")
                   
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetReportItem(string search, int limit, int offset)
        {
            return this.returnJson("{}");
        }

        public JsonResult GetAllHistory(string Id, int limit, int offset)
        {
            var result = this.service
               .Pesquisar(x => x.codEpc == Id)
               .Select(x => new
               {
                   Id = x.Id,
                   awb = x.codEpc,
                   origin = x.tbEquipamento.tbLocalidade.noNome,
                   destiny = x.tbLocalidade.noNome,
                   //route = x.tbLocalidade.,
                   status = x.tbOperacao.noDesc,
                   dtAtualizacao = x.dthLog.ToString("d/MM/yyyy")

               });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }
    }
}

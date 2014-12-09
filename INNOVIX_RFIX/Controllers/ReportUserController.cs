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
    public class ReportUserController : ControllerBase
    {
        private ITbLogUsuarioService service;
        private ITbUsuarioService serviceUser;

        public ReportUserController(ITbLogUsuarioService service, ITbUsuarioService serviceUser)
        {
            this.service = service;
            this.serviceUser = serviceUser;
        }

        public ViewResult List()
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
                   dthLog = x.dthLog.ToString("dd/MM/yyyy"),
                   noDesc = x.tbOperacao.noDesc,
                   noUsuario = x.tbUsuario.noUsuario,
                   codCpfCnpj = x.tbUsuario.codCpfCnpj
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset)
        {
            var result = this.serviceUser.GetLogOperador()
                .Select(x => new
                {
                    operador = x.Operador,
                    embarque = x.Embarque,
                    lacre = x.Lacre,
                    awb = x.AWB,
                    operacao = x.Operacao,
                    data = x.Data.ToString("d/MM/yyyy"),
                    localidade = x.Localidade
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count(), result);
        }

        public JsonResult GetReportItem(searchUser search, int limit, int offset, string predicate, string order)
        {
            var result = this.serviceUser.GetLogOperador()
                .Select(x => new
                {
                    operador = x.Operador,
                    embarque = x.Embarque,
                    lacre = x.Lacre,
                    awb = x.AWB,
                    operacao = x.Operacao,
                    data = x.Data.ToString("d/MM/yyyy"),
                    objData = x.Data,
                    localidade = x.Localidade
                });

            if (search.search != null)
                result = result.Where(x => x.operador.ToLower().Contains(search.search.ToLower()));

            if (search.dtAction.Year != 1)
                result = result.Where(x => x.objData.Date >= search.dtAction.Date && x.objData.Date <= search.dtAction.Date);

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

     public class searchUser
     {
         public string search { get; set; }
         public DateTime dtAction { get; set; }
     }
}

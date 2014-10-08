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

        public ReportUserController(ITbLogUsuarioService service)
        {
            this.service = service;
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
                   dthLog = x.dthLog,
                   noDesc = x.tbOperacao.noDesc,
                   noUsuario = x.tbUsuario.noUsuario,
                   codCpfCnpj = x.tbUsuario.codCpfCnpj
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
                    dthLog = x.dthLog,
                    noDesc = x.tbOperacao.noDesc,
                    noUsuario = x.tbUsuario.noUsuario,
                    codCpfCnpj = x.tbUsuario.codCpfCnpj
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetLogUser(int limit, int offset, string search, DateTime dtAction)
        {
            var result = this.service.GetLogUsuario(dtAction, search)
                .Select(x => new
            {
                Id = x.Id,
                dthLog = x.dthLog,
                noDesc = x.tbOperacao.noDesc,
                noUsuario = x.tbUsuario.noUsuario,
                codCpfCnpj = x.tbUsuario.codCpfCnpj
            });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }
    }
}

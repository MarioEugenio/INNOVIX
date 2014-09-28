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
    public class LocationController : ControllerBase
    {
        private ITbLocalidadeService service;

        public LocationController(ITbLocalidadeService service)
        {
            this.service = service;
        }

        public JsonResult Remove(int Id)
        {
            try
            {
                this.service.Excluir(Id);

                return this.returnMenssage("Registro removido com sucesso", true);
            }
            catch (ExceptionService ex)
            {

                return this.returnMenssage(ex.Message, false);
            }
        }

        public JsonResult Save(TbLocalidade entity)
        {
            try
            {
                this.service.Salvar(entity);

                return this.returnMenssage("Cadastro realizado com sucesso", true);
            } catch (ExceptionService ex) {

                return this.returnMenssage(ex.Message, false);
            }
        }

        public JsonResult Get(int Id)
        {
            var result = this.service
               .Pesquisar(x => x.Id == Id)
               .Select(x => new
               {
                   Id = x.Id,
                   noCidade = x.noCidade,
                   noDesc = x.noDesc,
                   noEstado = x.noEstado,
                   noNome = x.noNome,
                   noResponsavel = x.noResponsavel,
                   noTelefone = x.noTelefone
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll()
        {
            var result = this.service
                .Listar()
                .Select(x => new {
                    Id = x.Id,
                    noCidade = x.noCidade,
                    noDesc = x.noDesc,
                    noEstado = x.noEstado,
                    noNome = x.noNome,
                    noResponsavel = x.noResponsavel,
                    noTelefone = x.noTelefone
            });

            return this.returnJson(result);
        }

    }
}

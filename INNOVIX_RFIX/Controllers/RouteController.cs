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
    public class RouteController : ControllerBase
    {
        private ITbRotaService service;

        public RouteController(ITbRotaService service)
        {
            this.service = service;
        }

        public ViewResult List()
        {
            return View();
        }

        public ViewResult Create()
        {
            return View();
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

        public JsonResult Save(TbRota entity)
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
                   noDesc = x.noDesc,
                   noNome = x.noNome
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset)
        {
            var result = this.service
                .Listar()
                .Select(x => new {
                    Id = x.Id,
                    noDesc = x.noDesc,
                    noNome = x.noNome
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetRoute(string search, int limit, int offset)
        {
            var str = (search != "") ? search.ToLower() : null;
            var result = this.service
                .Pesquisar(x => x.noNome.ToLower().Contains(str))
                .Select(x => new
                {
                    Id = x.Id,
                    noDesc = x.noDesc,
                    noNome = x.noNome
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

    }
}

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
    public class RouteController : ControllerBase
    {
        private ITbRotaService service;
        private ITbLocalidadeService serviceLocalidade;
        private IRelLocalidadeRotaService serviceRel;

        public RouteController(ITbRotaService service, IRelLocalidadeRotaService serviceRl, ITbLocalidadeService serviceLocalidade)
        {
            this.service = service;
            this.serviceRel = serviceRl;
            this.serviceLocalidade = serviceLocalidade;
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

                if (entity.destiny > 0)
                {
                    this.service.Salvar(entity);
                    /*
                    RelLocalidadeRota relLocalidadeRota = new RelLocalidadeRota();
                    relLocalidadeRota.idLocalidade = this.serviceLocalidade.ObterPorId(entity.destiny).Id;
                    relLocalidadeRota.idRota = entity.Id;
                    relLocalidadeRota.tbLocalidade = this.serviceLocalidade.ObterPorId(entity.destiny);
                    relLocalidadeRota.tbRota = entity;
                    relLocalidadeRota.intCheckpoint = 0;
                    this.serviceRel.Salvar(relLocalidadeRota);*/
                }

                return this.returnMenssage("Processo realizado com sucesso", true);
            } catch (ExceptionService ex) {

                return this.returnMenssage(ex.Message, false);
            }
        }

        public JsonResult Get(int Id)
        {
            var rel = this.serviceRel.Pesquisar(x => x.tbRota.Id == Id);

            var result = this.service
               .Pesquisar(x => x.Id == Id)
               .Select(x => new
               {
                   Id = x.Id,
                   noDesc = x.noDesc.Trim(),
                   noNome = x.noNome.Trim(),
                   destiny = (rel.Count() > 0) ? rel.FirstOrDefault().tbLocalidade.Id : 0
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.service
                .Listar()
                .Select(x => new {
                    Id = x.Id,
                    noDesc = x.noDesc,
                    noNome = x.noNome
                });

            if (order == "ASC")
            {
                result = result.OrderBy(x => x.GetType().GetProperty(predicate).GetValue(x, null));
            }
            else
            {
                result = result.OrderByDescending(x => x.GetType().GetProperty(predicate).GetValue(x, null));
            }

            List<object> list = new List<object>();

            foreach(var item in result) {
                var rel = this.serviceRel.Pesquisar(x => x.tbRota.Id == item.Id);

                list.Add(new 
                {
                    Id = item.Id,
                    noDesc = item.noDesc,
                    noNome = item.noNome,
                    destiny = (rel.Count() > 0) ? rel.FirstOrDefault().tbLocalidade.noCidade : null
                });
            }

            return this.returnJson(list.Skip((offset - 1) * limit).Take(limit), list.Count(), result);
        }

        public JsonResult GetRoute(string search, int limit, int offset, string predicate, string order)
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
}

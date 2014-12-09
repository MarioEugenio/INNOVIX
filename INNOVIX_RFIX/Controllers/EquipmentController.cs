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
    public class EquipmentController : ControllerBase
    {
        private ITbEquipamentoService service;

        public EquipmentController(ITbEquipamentoService service)
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

        public JsonResult Save(TbEquipamento entity)
        {
            try
            {
                this.service.Salvar(entity);

                return this.returnMenssage("Processo realizado com sucesso", true);
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
                   noEquipamento = x.noEquipamento.Trim(),
                   localidade = (x.tbLocalidade != null) ? x.tbLocalidade.Id : 0
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.service
                .Listar()
                .Select(x => new {
                    Id = x.Id,
                    noEquipamento = x.noEquipamento,
                    localidade = (x.tbLocalidade != null) ? x.tbLocalidade.noNome : null,
                    dtAtualizacao = (x.tbLogsaco.GetType() == typeof(TbLogSaco))? x.tbLogsaco.LastOrDefault().dthLog.ToString("d/MM/yyyy") : null
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

        public JsonResult GetEquipment(string search, int limit, int offset, string predicate, string order)
        {
            var str = (search != "") ? search.ToLower() : null;
            var result = this.service
                .Pesquisar(x => x.noEquipamento.ToLower().Contains(str))
                .Select(x => new
                {
                    Id = x.Id,
                    noEquipamento = x.noEquipamento,
                    dtAtualizacao = (x.tbLogsaco.GetType() == typeof(TbLogSaco)) ? x.tbLogsaco.LastOrDefault().dthLog.ToString("d/MM/yyyy") : null
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

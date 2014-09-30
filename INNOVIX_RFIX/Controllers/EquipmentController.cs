﻿using Innovix.Base.Domain.Entity;
using Innovix.Base.Domain.Service;
using Innovix.Base.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INNOVIX_RFIX.Controllers
{
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
                   noEquipamento = x.noEquipamento,
                   idLocalidade = x.tbLocalidade.Id
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll()
        {
            var result = this.service
                .Listar()
                .Select(x => new {
                    Id = x.Id,
                    noEquipamento = x.noEquipamento,
                    noLocalidade = x.tbLocalidade.noNome
            });

            return this.returnJson(result);
        }

        public JsonResult GetEquipment(string search, int limit, int offset)
        {
            var str = (search != "") ? search.ToLower() : null;
            var result = this.service
                .Pesquisar(x => x.noEquipamento.ToLower().Contains(str))
                .Select(x => new
                {
                    Id = x.Id,
                    noEquipamento = x.noEquipamento,
                    noLocalidade = x.tbLocalidade.noNome
                }).Take(limit).Skip(offset);

            return this.returnJson(result);
        }
    }
}

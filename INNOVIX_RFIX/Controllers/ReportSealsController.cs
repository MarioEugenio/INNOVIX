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
     [Authorize]
    public class ReportSealsController : ControllerBase
    {
        private ITbSacoService serviceSaco;
        private ITbLogSacoService service;

        public ReportSealsController(ITbLogSacoService service, ITbSacoService serviceSaco)
        {
            this.service = service;
            this.serviceSaco = serviceSaco;
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
                   awb = x.codBarras,
                   origin = x.tbEquipamento.tbLocalidade.noNome,
                   destiny = x.tbLocalidade.noNome,
                   //route = null,
                   status = x.tbOperacao.noDesc,
                   dtAtualizacao = x.dthLog

               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.serviceSaco
                .Listar()
                .Select(x => new
                {
                    Id =  x.Id,
                      awb = x.tbLacre.indCodbarras,
                      origin = x.tbLote.tbLocalidade.noCidade,
                      destiny = x.tbLote.tbLocalidadeDest.noCidade,
                      //route = ,
                      //embarque = x.,
                      status = x.tbItem.FirstOrDefault().tbStatus.noDesc,
                      dtAtualizacao = x.dthCriacao.ToString("dd/MM/yyyy"),
                      responsavel = x.tbLote.tbLocalidade.noResponsavel,
                      lacre = x.tbLacre.Id,
                      dtCadastro = x.tbItem.FirstOrDefault().dthCriacao.ToString("dd/MM/yyyy"),
                      //epc = '0000000000000001111111542'
                });

            return this.returnJson(result.Skip((offset - 1) * limit).Take(limit), result.Count());
        }

        public JsonResult GetReportItem(string search, int limit, int offset, string predicate, string order)
        {
            return this.returnJson("{}");
        }

        public JsonResult GetAllHistory(int Id, int limit, int offset, string predicate, string order)
        {
            return this.returnJson("{}");
        }
    }
}

using Innovix.Base.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INNOVIX_RFIX.Controllers
{
    public class ProfileController : ControllerBase
    {
        private ItbPerfilService servicePerfil;

        public ProfileController(ItbPerfilService servicePerfil)
        {
            this.servicePerfil = servicePerfil;
        }

        //
        // GET: /Profile/

        public JsonResult GetAll()
        {
            var result = this.servicePerfil
                .Listar()
                .Select(x => new { 
                Id = x.Id,
                noDesc = x.noDesc
            });

            return this.returnJson(result);
        }

    }
}

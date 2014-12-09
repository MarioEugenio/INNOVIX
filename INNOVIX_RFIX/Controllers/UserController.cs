using Innovix.Base.Domain.Entity;
using Innovix.Base.Domain.Service;
using Innovix.Base.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace INNOVIX_RFIX.Controllers
{
    [Authorize]
    public class UserController : ControllerBase
    {
        private ITbUsuarioService service;

        public UserController(ITbUsuarioService service)
        {
            this.service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AuthenticateRequest(string username, string password)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] == null)
                {
                    try
                    {
                        //let us take out the username now                
                        string roles = string.Empty;
                        
                        var user = service.Pesquisar(z => z.codCpfCnpj.Equals(username)).FirstOrDefault();

                        if (user != null) {
                            var str = System.Text.Encoding.Default.GetString(user.codSenha);
                            var str2 = System.Text.Encoding.Default.GetString(this.service.GetHashAuth(password));

                            if (str != str2)
                            {
                                return this.returnMenssage("Senha inválida", false);
                            }
                        }

                        if (user == null)
                            return this.returnMenssage("Login inválido", false);

                        roles = user.tbPerfil.noDesc;

                        FormsAuthentication.SetAuthCookie(user.noUsuario,true);
                        Session["role"] = roles.ToUpper();

                        //Let us set the Pricipal with our user specific details
                        System.Web.HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(user.noUsuario, "Forms"), roles.Split(';'));

                        return this.returnMenssage("Autenticado com sucesso", true);
                    }
                    catch (Exception ex)
                    {
                        return this.returnMenssage(ex.Message, false);
                    }
                }
            }

            return this.returnMenssage("Não foi possível realizar a autenticação", false);
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

        public JsonResult Save(TbUsuario entity)
        {
            try
            {
                entity.codSenha = this.service.GetHashAuth(entity.password);
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
                   noEmail = x.noEmail.Trim(),
                   noTelefone = x.noTelefone.Trim(),
                   noUsuario = x.noUsuario.Trim(),
                   codCpfCnpj = x.codCpfCnpj.Trim(),
                   idPerfil = x.tbPerfil.Id,
                   noPerfil = x.tbPerfil.noDesc.Trim()
               });

            return this.returnJson(result);
        }

        public JsonResult GetAll(int limit, int offset, string predicate, string order)
        {
            var result = this.service
                .Listar()
                .Select(x => new {
                    Id = x.Id,
                    noEmail = x.noEmail,
                    noTelefone = x.noTelefone,
                    noUsuario = x.noUsuario,
                    codCpfCnpj = x.codCpfCnpj,
                    idPerfil = (x.tbPerfil != null) ? x.tbPerfil.Id : 0,
                    noPerfil = (x.tbPerfil != null) ? x.tbPerfil.noDesc : null,
                    password = x.codSenha
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

        public JsonResult GetUser(string search, int limit, int offset, string predicate, string order)
        {
            var str = (search != "") ? search.ToLower() : null;
            var result = this.service
                .Pesquisar(x => x.noUsuario.ToLower().Contains(str))
                .Select(x => new
                {
                    Id = x.Id,
                    noEmail = x.noEmail,
                    noTelefone = x.noTelefone,
                    noUsuario = x.noUsuario,
                    codCpfCnpj = x.codCpfCnpj,
                    id_perfil = x.tbPerfil.Id,
                    no_perfil = x.tbPerfil.noDesc
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

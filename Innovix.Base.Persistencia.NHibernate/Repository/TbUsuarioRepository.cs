using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using Innovix.Base.Domain.Entity;
using Innovix.Base.Persistencia.NHibernate.Repository;
using Innovix.Base.Domain.Repository;
using Innovix.Base.Domain.DTO;

namespace Innovix.Base.Data.NHibernate.Repository
{ 
    public class TbUsuarioRepository : RepositoryNHibernate<TbUsuario>, ITbUsuarioRepository
    {
		public TbUsuarioRepository(ISession session) : base(session) { }

		public IEnumerable<TbUsuario> GetHashAuth (string password) {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"SELECT HashBytes('MD5', rtrim(ltrim(" + password + "))) as codSenha");

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(TbUsuario))).List<TbUsuario>().ToList();

            return objeto;
        }

        public List<LogOperador> GetLogOperador()
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_log_operadores");

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(LogOperador))).List<LogOperador>().ToList();

            return objeto;
        }
	}
}
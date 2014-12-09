using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using Innovix.Base.Domain.Entity;
using Innovix.Base.Persistencia.NHibernate.Repository;
using Innovix.Base.Domain.Repository;

namespace Innovix.Base.Data.NHibernate.Repository
{ 
    public class TbLogUsuarioRepository : RepositoryNHibernate<TbLogUsuario>, ITbLogUsuarioRepository
    {
		public TbLogUsuarioRepository(ISession session) : base(session) { }

        public IList<TbLogUsuario> GetLogUsuario(DateTime dtAction, string search)
        {
            var lista = this.Session.QueryOver<TbLogUsuario>()
                .List<TbLogUsuario>();

            if (dtAction != null)
            {
                lista.Where(x => x.dthLog == dtAction);
            }

            if (search != null)
            {
                lista.Where(x => x.tbUsuario.noUsuario.ToLower().Contains(search.ToString().ToLower()) 
                    || x.tbUsuario.codCpfCnpj.Contains(search.ToString()));
            }

            return lista;
        }
	}
}
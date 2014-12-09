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
    public class TbLogLoteRepository : RepositoryNHibernate<TbLogLote>, ITbLogLoteRepository
    {
		public TbLogLoteRepository(ISession session) : base(session) { }

		// Coloque aqui os métodos do serviço que se fizerem necessários. Os métodos comuns de CRUD já estão contemplados :)
	}
}
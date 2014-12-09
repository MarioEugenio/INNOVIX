using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using Innovix.Base.Domain.Entity;
using Innovix.Base.Persistencia.NHibernate.Repository;
using Innovix.Base.Domain.Repository;
using System.Web.Mvc;
using NHibernate.Transform;
using Innovix.Base.Domain.DTO;

namespace Innovix.Base.Data.NHibernate.Repository
{ 
    public class TbLoteRepository : RepositoryNHibernate<TbLote>, ITbLoteRepository
    {
		public TbLoteRepository(ISession session) : base(session) { }

        public List<LoteDTO> GetLotes()
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_lotes");

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(LoteDTO))).List<LoteDTO>().ToList();

            return objeto;
        }

        public List<LacreDetalhesDTO> GetLoteDetalhes(int id)
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_detalhes_lacre :par_id_lacre")
                .SetParameter("par_id_lacre", id);

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(LacreDetalhesDTO))).List<LacreDetalhesDTO>().ToList();

            return objeto;
        }
	}
}
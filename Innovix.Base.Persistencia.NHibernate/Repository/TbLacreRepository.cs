using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using Innovix.Base.Domain.Entity;
using Innovix.Base.Persistencia.NHibernate.Repository;
using Innovix.Base.Domain.Repository;
using Innovix.Base.Domain.DTO;
using System.Web.Mvc;
using NHibernate.Transform;

namespace Innovix.Base.Data.NHibernate.Repository
{ 
    public class TbLacreRepository : RepositoryNHibernate<TbLacre>, ITbLacreRepository
    {
		public TbLacreRepository(ISession session) : base(session) { }

        public List<LacreDTO> GetLacres()
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_lacres");

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(LacreDTO))).List<LacreDTO>().ToList();

            return objeto;
        }

        public List<LacreDetalhesDTO> GetItemDetalhes(int id)
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_detalhes_lacre :par_id_lacre")
                .SetParameter("par_id_lacre", id);

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(LacreDetalhesDTO))).List<LacreDetalhesDTO>().ToList();

            return objeto;
        }
	}
}
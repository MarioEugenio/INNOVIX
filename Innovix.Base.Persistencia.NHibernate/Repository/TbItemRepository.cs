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
    public class TbItemRepository : RepositoryNHibernate<TbItem>, ITbItemRepository
    {
        private ISession sessao;
        public TbItemRepository(ISession session) : base(session) { }

        public List<ItemDTO> GetItems()
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_itens");

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(ItemDTO))).List<ItemDTO>().ToList();

            return objeto;
        }

        public List<ItemDetalhesDTO> GetItemDetalhes(int id)
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_detalhes_item :par_id_item")
                .SetParameter("par_id_item", id);

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(ItemDetalhesDTO))).List<ItemDetalhesDTO>().ToList();

            return objeto;
        }

        public List<ItemLacreDTO> GetItemLacre(int id)
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_itens_lacre :par_id_lacre")
                .SetParameter("par_id_lacre", id);

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(ItemLacreDTO))).List<ItemLacreDTO>().ToList();

            return objeto;
        }

        public List<ItemLoteDTO> GetItemLote(int id)
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_itens_lote :par_id_lote")
                .SetParameter("par_id_lote", id);

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(ItemLoteDTO))).List<ItemLoteDTO>().ToList();

            return objeto;
        }

        public List<ItemHistoricoDTO> GetItemHistorico(int id)
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_historico_item :par_id_item")
                .SetParameter("par_id_item", id);

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(ItemHistoricoDTO))).List<ItemHistoricoDTO>().ToList();

            return objeto;
        }

        public List<ItemHistoricoLoteDTO> GetItemHistoricoLote(int id)
        {
            var session = DependencyResolver.Current.GetService<ISession>();

            var query = Session.CreateSQLQuery(@"EXEC dbRfix.dbo.p_consulta_historico_lote :par_id_lote")
                .SetParameter("par_id_lote", id);

            var objeto = query.SetResultTransformer(Transformers.AliasToBean(typeof(ItemHistoricoLoteDTO))).List<ItemHistoricoLoteDTO>().ToList();

            return objeto;
        }

    }
}
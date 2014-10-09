using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbRotaMap : ClassMap<TbRota> {
        
        public TbRotaMap() {
			Table("tb_rota");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_rota");
			Map(x => x.noNome).Column("no_nome").Not.Nullable().Length(50);
			Map(x => x.noDesc).Column("no_desc").Length(100);

			HasMany<RelLocalidadeRota>(x => x.relLocalidadeRota)
                .KeyColumn("id_rota")
                .LazyLoad()
              .Generic()
              .Inverse()
              .Cascade
              .AllDeleteOrphan();

			//HasMany(x => x.tbLote).KeyColumn("id_rota");
			HasMany<TbSincRota>(x => x.tbSincRota)
                .KeyColumn("id_rota")
                .LazyLoad()
              .Generic()
              .Inverse()
              .Cascade
              .AllDeleteOrphan();
        }
    }
}

using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLoteMap : ClassMap<TbLote> {
        
        public TbLoteMap() {
			Table("tb_lote");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_lote");

            References(x => x.tbLocalidade)
                .Column("id_localidade")
                .LazyLoad()
                .Cascade
                .None();

            References(x => x.tbLocalidadeDest)
                .Column("id_destino")
                .LazyLoad()
                .Cascade
                .None();

			References(x => x.tbRota)
                .Column("id_rota")
                .LazyLoad()
                .Cascade
                .None();

			Map(x => x.noDesc).Column("no_desc").Length(50);
			Map(x => x.dthCriacao).Column("dth_criacao").Not.Nullable();

			HasMany<TbItem>(x => x.tbItem)
                .KeyColumn("id_lote")
                .LazyLoad()
              .Generic()
              .Cascade
              .AllDeleteOrphan(); 

			HasMany<TbSaco>(x => x.tbSaco)
                .KeyColumn("id_lote")
                .LazyLoad()
              .Generic()
              .Cascade
              .AllDeleteOrphan();
        }
    }
}

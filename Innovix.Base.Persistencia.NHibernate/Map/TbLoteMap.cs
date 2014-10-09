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
			References(x => x.tbLocalidade).Column("id_localidade");
            References(x => x.tbLocalidadeDest).Column("id_destino");
			References(x => x.tbRota).Column("id_rota");
			Map(x => x.noDesc).Column("no_desc").Length(50);
			Map(x => x.dthCriacao).Column("dth_criacao").Not.Nullable();
			HasMany(x => x.tbItem).KeyColumn("id_lote");
			HasMany(x => x.tbSaco).KeyColumn("id_lote");
        }
    }
}

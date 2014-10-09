using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbSacoMap : ClassMap<TbSaco> {
        
        public TbSacoMap() {
			Table("tb_saco");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_saco");
			References(x => x.tbSaco).Column("id_sacopai");
			References(x => x.tbLacre).Column("id_lacre");
			References(x => x.tbLote).Column("id_lote");
			Map(x => x.dthCriacao).Column("dth_criacao").Not.Nullable();
			HasMany(x => x.tbItem).KeyColumn("id_saco");
			HasMany(x => x.listSaco).KeyColumn("id_sacopai");
        }
    }
}

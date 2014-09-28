using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLacreMap : ClassMap<TbLacre> {
        
        public TbLacreMap() {
			Table("tb_lacre");
			LazyLoad();
			Id(x => x.idLacre).GeneratedBy.Identity().Column("id_lacre");
			Map(x => x.dthCriacao).Column("dth_criacao").Not.Nullable();
			Map(x => x.indCodbarras).Column("ind_codBarras").Precision(10);
			HasMany(x => x.tbSaco).KeyColumn("id_lacre");
        }
    }
}

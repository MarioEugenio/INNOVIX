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
			Id(x => x.Id).GeneratedBy.Identity().Column("id_lacre");
			Map(x => x.dthCriacao).Column("dth_criacao").Not.Nullable();
			Map(x => x.indCodbarras).Column("cod_barras");

			HasMany<TbSaco>(x => x.tbSaco)
                .KeyColumn("id_lacre")
                .LazyLoad()
              .Generic()
              .Cascade
              .AllDeleteOrphan();
        }
    }
}

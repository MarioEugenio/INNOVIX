using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbControleMap : ClassMap<TbControle> {
        
        public TbControleMap() {
			Table("tb_controle");
			LazyLoad();
			Map(x => x.idControle).Column("id_controle").Not.Nullable().Precision(10);
			Map(x => x.noCliente).Column("no_cliente").Length(50);
			Map(x => x.dtValidade).Column("dt_validade");
			Map(x => x.stExpira).Column("st_expira").Precision(10);
        }
    }
}

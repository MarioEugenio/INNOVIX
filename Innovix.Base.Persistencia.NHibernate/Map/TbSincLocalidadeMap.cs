using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbSincLocalidadeMap : ClassMap<TbSincLocalidade> {
        
        public TbSincLocalidadeMap() {
			Table("tb_sinc_localidade");
			LazyLoad();
            CompositeId().KeyProperty(x => x.idLocalidade, "id_localidade")
                         .KeyProperty(x => x.idEquipamento, "id_equipamento");

			References(x => x.tbLocalidade).Column("id_localidade");
			References(x => x.tbEquipamento).Column("id_equipamento");
			Map(x => x.indEnviado).Column("ind_enviado").Not.Nullable().Length(1);
			Map(x => x.dthEnviado).Column("dth_enviado");
        }
    }
}

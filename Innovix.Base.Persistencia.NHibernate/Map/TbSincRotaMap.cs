using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbSincRotaMap : ClassMap<TbSincRota> {
        
        public TbSincRotaMap() {
			Table("tb_sinc_rota");
			LazyLoad();
			References(x => x.tbRota).Column("id_rota");
			References(x => x.tbEquipamento).Column("id_equipamento");
			Map(x => x.indEnviado).Column("ind_enviado").Not.Nullable().Length(1);
			Map(x => x.dthEnviado).Column("dth_enviado");
        }
    }
}

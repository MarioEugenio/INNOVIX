using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbSincRfidMap : ClassMap<TbSincRfid> {
        
        public TbSincRfidMap() {
			Table("tb_sinc_rfid");
			LazyLoad();
			References(x => x.tbRfid).Column("id_rfid");
			References(x => x.tbEquipamento).Column("id_equipamento");
			Map(x => x.indEnviado).Column("ind_enviado").Not.Nullable().Length(1);
			Map(x => x.dthEnviado).Column("dth_enviado");
        }
    }
}

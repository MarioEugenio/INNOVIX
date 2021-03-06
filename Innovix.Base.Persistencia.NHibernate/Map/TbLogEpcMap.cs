using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLogEpcMap : ClassMap<TbLogEpc> {
        
        public TbLogEpcMap() {
			Table("tb_log_epc");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_log_epc");
			References(x => x.tbOperacao).Column("id_operacao");
			References(x => x.tbEquipamento).Column("id_equipamento");
			References(x => x.tbUsuario).Column("id_usuario");
			References(x => x.tbLocalidade).Column("id_localidade");
			Map(x => x.codEpc).Column("cod_epc").Not.Nullable().Length(32);
			Map(x => x.dthLog).Column("dth_log").Not.Nullable();
        }
    }
}

using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLogsacoMap : ClassMap<TbLogsaco> {
        
        public TbLogsacoMap() {
			Table("tb_logsaco");
			LazyLoad();
			Id(x => x.idLogsaco).GeneratedBy.Identity().Column("id_logsaco");
			References(x => x.tbSaco).Column("id_saco");
			References(x => x.tbOperacao).Column("id_operacao");
			References(x => x.tbEquipamento).Column("id_equipamento");
			References(x => x.tbUsuario).Column("id_usuario");
			References(x => x.tbLocalidade).Column("id_localidade");
			Map(x => x.dthLog).Column("dth_log").Not.Nullable();
        }
    }
}

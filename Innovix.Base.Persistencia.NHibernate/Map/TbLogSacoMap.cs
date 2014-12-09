using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLogSacoMap : ClassMap<TbLogSaco> {
        
        public TbLogSacoMap() {
			Table("tb_log_saco");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_log_saco");
			References(x => x.tbOperacao).Column("id_operacao");
			References(x => x.tbEquipamento).Column("id_equipamento");
			References(x => x.tbUsuario).Column("id_usuario");
			References(x => x.tbLocalidade).Column("id_localidade");
			Map(x => x.codBarras).Column("cod_barras").Length(32);
			Map(x => x.dthLog).Column("dth_log");
        }
    }
}

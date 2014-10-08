using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLogLoteMap : ClassMap<TbLogLote> {
        
        public TbLogLoteMap() {
			Table("tb_log_lote");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_log_lote");
			References(x => x.tbOperacao).Column("id_operacao");
			References(x => x.tbEquipamento).Column("id_equipamento");
			References(x => x.tbUsuario).Column("id_usuario");
			References(x => x.tbLocalidade).Column("id_localidade");
			Map(x => x.noNome).Column("no_nome").Length(50);
			Map(x => x.dthLog).Column("dth_log").Not.Nullable();
        }
    }
}

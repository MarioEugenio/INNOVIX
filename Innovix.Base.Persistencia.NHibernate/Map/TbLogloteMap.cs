using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLogloteMap : ClassMap<TbLoglote> {
        
        public TbLogloteMap() {
			Table("tb_loglote");
			LazyLoad();
			Id(x => x.idLoglote).GeneratedBy.Identity().Column("id_loglote");
			References(x => x.tbLote).Column("id_lote");
			References(x => x.tbOperacao).Column("id_operacao");
			References(x => x.tbEquipamento).Column("id_equipamento");
			References(x => x.tbUsuario).Column("id_usuario");
			References(x => x.tbLocalidade).Column("id_localidade");
			Map(x => x.dthLog).Column("dth_log").Not.Nullable();
        }
    }
}

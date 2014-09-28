using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbSincronizacaoMap : ClassMap<TbSincronizacao> {
        
        public TbSincronizacaoMap() {
			Table("tb_sincronizacao");
			LazyLoad();
			References(x => x.tbItem).Column("id_item");
			References(x => x.tbEquipamento).Column("id_equipamento");
			Map(x => x.indEnviado).Column("ind_enviado").Not.Nullable().Length(1);
			Map(x => x.dthEnviado).Column("dth_enviado").Not.Nullable();
        }
    }
}

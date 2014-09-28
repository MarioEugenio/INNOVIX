using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLogitemMap : ClassMap<TbLogitem> {
        
        public TbLogitemMap() {
			Table("tb_logitem");
			LazyLoad();
			Id(x => x.idLogitem).GeneratedBy.Identity().Column("id_logitem");
			References(x => x.tbItem).Column("id_item");
			References(x => x.tbOperacao).Column("id_operacao");
			References(x => x.tbEquipamento).Column("id_equipamento");
			References(x => x.tbUsuario).Column("id_usuario");
			References(x => x.tbLocalidade).Column("id_localidade");
			Map(x => x.dthLog).Column("dth_log").Not.Nullable();
        }
    }
}

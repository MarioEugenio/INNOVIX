using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbSincPerfilMap : ClassMap<TbSincPerfil> {
        
        public TbSincPerfilMap() {
			Table("tb_sinc_perfil");
			LazyLoad();
			References(x => x.tbPerfil).Column("id_perfil");
			References(x => x.tbEquipamento).Column("id_equipamento");
			Map(x => x.indEnviado).Column("ind_enviado").Not.Nullable().Length(1);
			Map(x => x.dthEnviado).Column("dth_enviado");
        }
    }
}

using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLogUsuarioMap : ClassMap<TbLogUsuario> {
        
        public TbLogUsuarioMap() {
			Table("tb_log_usuario");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_logusuario");
			References(x => x.tbUsuario).Column("id_usuario");
			References(x => x.tbOperacao).Column("id_operacao");
			Map(x => x.dthLog).Column("dth_log");
        }
    }
}

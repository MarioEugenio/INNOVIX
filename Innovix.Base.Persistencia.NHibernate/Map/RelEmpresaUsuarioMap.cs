using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class RelEmpresaUsuarioMap : ClassMap<RelEmpresaUsuario> {
        
        public RelEmpresaUsuarioMap() {
			Table("rel_empresa_usuario");
			LazyLoad();
			CompositeId().KeyProperty(x => x.idEmpresa, "id_empresa")
			             .KeyProperty(x => x.idUsuario, "id_usuario");
			References(x => x.tbEmpresa).Column("id_empresa");
			References(x => x.tbUsuario).Column("id_usuario");
        }
    }
}

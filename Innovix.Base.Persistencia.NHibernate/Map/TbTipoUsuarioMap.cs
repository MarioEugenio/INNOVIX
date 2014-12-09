using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbTipoUsuarioMap : ClassMap<TbTipoUsuario> {
        
        public TbTipoUsuarioMap() {
			Table("tb_tipo_usuario");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_tipo_usuario");
			Map(x => x.noDesc).Column("no_desc").Length(30);
			HasMany(x => x.tbUsuario).KeyColumn("id_tipo_usuario");
        }
    }
}

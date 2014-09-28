using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbPerfilMap : ClassMap<TbPerfil> {
        
        public TbPerfilMap() {
			Table("tb_perfil");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_perfil");
			Map(x => x.noDesc).Column("no_desc").Not.Nullable().Length(50);
			//HasMany(x => x.relPerfilOperacao).KeyColumn("id_perfil");
			//HasMany(x => x.tbSincPerfil).KeyColumn("id_perfil");
			HasMany(x => x.tbUsuario).KeyColumn("id_perfil");
        }
    }
}

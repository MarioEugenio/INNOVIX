using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class RelPerfilOperacaoMap : ClassMap<RelPerfilOperacao> {
        
        public RelPerfilOperacaoMap() {
			Table("rel_perfil_operacao");
			LazyLoad();
			CompositeId().KeyProperty(x => x.idPerfil, "id_perfil")
			             .KeyProperty(x => x.idOperacao, "id_operacao");
			References(x => x.tbPerfil).Column("id_perfil");
			References(x => x.tbOperacao).Column("id_operacao");
        }
    }
}

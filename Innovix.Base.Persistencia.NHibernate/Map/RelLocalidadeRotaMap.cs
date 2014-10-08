using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class RelLocalidadeRotaMap : ClassMap<RelLocalidadeRota> {
        
        public RelLocalidadeRotaMap() {
			Table("rel_localidade_rota");
			LazyLoad();
			CompositeId().KeyProperty(x => x.idLocalidade, "id_localidade")
			             .KeyProperty(x => x.idRota, "id_rota");
			References(x => x.tbLocalidade).Column("id_localidade");
			References(x => x.tbRota).Column("id_rota");
			Map(x => x.intCheckpoint).Column("int_checkpoint").Not.Nullable().Precision(10);
        }
    }
}

using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class RelEmpresaItemMap : ClassMap<RelEmpresaItem> {
        
        public RelEmpresaItemMap() {
			Table("rel_empresa_item");
			LazyLoad();
			CompositeId().KeyProperty(x => x.idEmpresa, "id_empresa")
			             .KeyProperty(x => x.idItem, "id_item");
			References(x => x.tbEmpresa).Column("id_empresa");
			References(x => x.tbItem).Column("id_item");
        }
    }
}

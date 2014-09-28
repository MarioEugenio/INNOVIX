using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class RelEmpresaEquipamentoMap : ClassMap<RelEmpresaEquipamento> {
        
        public RelEmpresaEquipamentoMap() {
			Table("rel_empresa_equipamento");
			LazyLoad();
			CompositeId().KeyProperty(x => x.idEmpresa, "id_empresa")
			             .KeyProperty(x => x.idEquipamento, "id_equipamento");
			References(x => x.tbEmpresa).Column("id_empresa");
			References(x => x.tbEquipamento).Column("id_equipamento");
        }
    }
}

using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbEmpresaMap : ClassMap<TbEmpresa> {
        
        public TbEmpresaMap() {
			Table("tb_empresa");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_empresa");
			Map(x => x.noEmpresa).Column("no_empresa").Not.Nullable().Length(50);
			Map(x => x.noDesc).Column("no_desc").Length(200);
			Map(x => x.noEndereco).Column("no_endereco").Length(100);
			Map(x => x.noTelefone).Column("no_telefone").Length(15);
        }
    }
}

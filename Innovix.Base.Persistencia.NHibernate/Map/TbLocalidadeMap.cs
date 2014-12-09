using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbLocalidadeMap : ClassMap<TbLocalidade> {
        
        public TbLocalidadeMap() {
			Table("tb_localidade");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_localidade");
			Map(x => x.noDesc).Column("no_desc").Length(50);
			Map(x => x.noNome).Column("no_nome").Length(50);
			Map(x => x.noCidade).Column("no_cidade").Length(50);
			Map(x => x.noTelefone).Column("no_telefone").Length(13);
			Map(x => x.noResponsavel).Column("no_responsavel").Length(50);
			Map(x => x.noEstado).Column("no_estado").Length(2);
			//HasMany(x => x.relLocalidadeRota).KeyColumn("id_localidade");
			
            HasMany<TbEquipamento>(x => x.tbEquipamento)
                .KeyColumn("id_localidade")
                .LazyLoad()
              .Generic();

            HasMany<TbItem>(x => x.tbItemDestino)
                .KeyColumn("id_destino")
                .LazyLoad()
              .Generic();
			
            HasMany<TbItem>(x => x.tbItem)
                .KeyColumn("id_localidade")
                .LazyLoad()
              .Generic();

			//HasMany(x => x.tbLogitem).KeyColumn("id_localidade");
			//HasMany(x => x.tbLoglote).KeyColumn("id_localidade");
			//HasMany(x => x.tbLogsaco).KeyColumn("id_localidade");
			//HasMany(x => x.tbLote).KeyColumn("id_destino");
			//HasMany(x => x.tbLote).KeyColumn("id_localidade");
			/*HasMany<TbSincLocalidade>(x => x.tbSincLocalidade)
                .KeyColumn("id_localidade")
                .LazyLoad()
              .Generic()
              .Inverse()
              .Cascade
              .AllDeleteOrphan();*/
        }
    }
}

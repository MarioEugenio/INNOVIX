using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbEquipamentoMap : ClassMap<TbEquipamento> {
        
        public TbEquipamentoMap() {
			Table("tb_equipamento");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_equipamento");
			References(x => x.tbLocalidade).Column("id_localidade");
			Map(x => x.noEquipamento).Column("no_equipamento").Length(50);
			//HasMany(x => x.relEmpresaEquipamento).KeyColumn("id_equipamento");
            HasMany<TbLogEpc>(x => x.tbLogEpc)
                .KeyColumn("id_equipamento")
                .LazyLoad()
              .Generic()
              .Cascade
              .AllDeleteOrphan();

			HasMany<TbLogLote>(x => x.tbLoglote)
                .KeyColumn("id_equipamento")
                .LazyLoad()
              .Generic()
              .Cascade
              .AllDeleteOrphan();

			HasMany<TbLogSaco>(x => x.tbLogsaco)
                .KeyColumn("id_equipamento")
                .LazyLoad()
              .Generic()
              .Cascade
              .AllDeleteOrphan();

			//HasMany(x => x.tbSincLocalidade).KeyColumn("id_equipamento");
			//HasMany(x => x.tbSincOperacao).KeyColumn("id_equipamento");
			//HasMany(x => x.tbSincPerfil).KeyColumn("id_equipamento");
			//HasMany(x => x.tbSincRfid).KeyColumn("id_equipamento");
			//HasMany(x => x.tbSincRota).KeyColumn("id_equipamento");
			//HasMany(x => x.tbSincUsuario).KeyColumn("id_equipamento");
			//HasMany(x => x.tbSincronizacao).KeyColumn("id_equipamento");
        }
    }
}

using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbItemMap : ClassMap<TbItem> {
        
        public TbItemMap() {
			Table("tb_item");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_item");
			References(x => x.tbStatus).Column("id_status");
			//References(x => x.tbRfid).Column("id_rfid");
			//References(x => x.tbSaco).Column("id_saco");
			//References(x => x.tbLote).Column("id_lote");
			References(x => x.tbLocalidade).Column("id_localidade");
			//References(x => x.idDestino).Column("id_destino");
			Map(x => x.codBarras).Column("cod_barras").Length(50);
			Map(x => x.dthCriacao).Column("dth_criacao").Not.Nullable();
			Map(x => x.noDesc).Column("no_desc").Length(100);
			//HasMany(x => x.relEmpresaItem).KeyColumn("id_item");
			//HasMany(x => x.tbLogitem).KeyColumn("id_item");
			//HasMany(x => x.tbSincronizacao).KeyColumn("id_item");
        }
    }
}

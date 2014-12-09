using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbRfidMap : ClassMap<TbRfid> {
        
        public TbRfidMap() {
			Table("tb_rfid");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_rfid");
			Map(x => x.codRpc).Column("cod_rpc").Length(32);
			Map(x => x.dthCriacao).Column("dth_criacao").Not.Nullable();
			HasMany(x => x.tbItem).KeyColumn("id_rfid");
        }
    }
}

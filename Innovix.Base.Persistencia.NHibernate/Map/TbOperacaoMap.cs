using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbOperacaoMap : ClassMap<TbOperacao> {
        
        public TbOperacaoMap() {
			Table("tb_operacao");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_operacao");
			Map(x => x.noDesc).Column("no_desc").Not.Nullable().Length(50);
			//HasMany(x => x.relPerfilOperacao).KeyColumn("id_operacao");
			HasMany(x => x.tbLogUsuario).KeyColumn("id_operacao");
			//HasMany(x => x.tbLogitem).KeyColumn("id_operacao");
			//HasMany(x => x.tbLoglote).KeyColumn("id_operacao");
			//HasMany(x => x.tbLogsaco).KeyColumn("id_operacao");
			//HasMany(x => x.tbSincOperacao).KeyColumn("id_operacao");
        }
    }
}

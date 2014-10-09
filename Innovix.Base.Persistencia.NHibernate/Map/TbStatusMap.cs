using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbStatusMap : ClassMap<TbStatus> {
        
        public TbStatusMap() {
			Table("tb_status");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_status");
			Map(x => x.noDesc).Column("no_desc").Length(50);

			HasMany<TbItem>(x => x.tbItem)
                .KeyColumn("id_status")
                .LazyLoad()
              .Generic()
              .Cascade
              .AllDeleteOrphan();
        }
    }
}

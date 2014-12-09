using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbRota : EntityBase
    {
        public TbRota() {
			relLocalidadeRota = new List<RelLocalidadeRota>();
			tbLote = new List<TbLote>();
        }
        [NotNullNotEmpty]
        [Length(50)]
        public virtual string noNome { get; set; }
        [Length(100)]
        public virtual string noDesc { get; set; }
        public virtual IList<RelLocalidadeRota> relLocalidadeRota { get; set; }
        public virtual IList<TbLote> tbLote { get; set; }
        public virtual int destiny { get; set; }
    }
}

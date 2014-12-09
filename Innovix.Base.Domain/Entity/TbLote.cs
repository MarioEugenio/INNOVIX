using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbLote : EntityBase
    {
        public TbLote() {
			tbItem = new List<TbItem>();
			tbSaco = new List<TbSaco>();
        }
        public virtual int idLote { get; set; }
        public virtual TbLocalidade tbLocalidade { get; set; }
        public virtual TbLocalidade tbLocalidadeDest { get; set; }
        public virtual TbRota tbRota { get; set; }
        [Length(50)]
        public virtual string noDesc { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthCriacao { get; set; }
        public virtual IList<TbItem> tbItem { get; set; }
        public virtual IList<TbSaco> tbSaco { get; set; }
    }
}

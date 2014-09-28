using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbLacre : EntityBase
    {
        public TbLacre() {
			tbSaco = new List<TbSaco>();
        }
        public virtual int idLacre { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthCriacao { get; set; }
        public virtual int? indCodbarras { get; set; }
        public virtual IList<TbSaco> tbSaco { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbSaco : EntityBase
    {
        public TbSaco() {
			tbItem = new List<TbItem>();
            listSaco = new List<TbSaco>();
        }
        public virtual int idSaco { get; set; }
        public virtual TbSaco tbSaco { get; set; }
        public virtual TbLacre tbLacre { get; set; }
        public virtual TbLote tbLote { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthCriacao { get; set; }
        public virtual IList<TbItem> tbItem { get; set; }
        public virtual IList<TbSaco> listSaco { get; set; }
    }
}

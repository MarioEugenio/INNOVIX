using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbSaco : EntityBase
    {
        public TbSaco() {
			tbItem = new List<TbItem>();
			tbLogsaco = new List<TbLogsaco>();
			tbSaco = new List<TbSaco>();
        }
        public virtual int idSaco { get; set; }
        public virtual TbLacre tbLacre { get; set; }
        public virtual TbLote tbLote { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthCriacao { get; set; }
        public virtual IList<TbItem> tbItem { get; set; }
        public virtual IList<TbLogsaco> tbLogsaco { get; set; }
        public virtual IList<TbSaco> tbSaco { get; set; }
    }
}

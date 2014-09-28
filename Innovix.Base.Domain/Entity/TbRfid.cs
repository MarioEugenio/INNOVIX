using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbRfid : EntityBase
    {
        public TbRfid() {
			tbItem = new List<TbItem>();
			tbSincRfid = new List<TbSincRfid>();
        }
        public virtual int idRfid { get; set; }
        [Length(32)]
        public virtual string codRpc { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthCriacao { get; set; }
        public virtual IList<TbItem> tbItem { get; set; }
        public virtual IList<TbSincRfid> tbSincRfid { get; set; }
    }
}

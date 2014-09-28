using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbStatus : EntityBase
    {
        public TbStatus() {
			tbItem = new List<TbItem>();
        }
        [Length(50)]
        public virtual string noDesc { get; set; }
        public virtual IList<TbItem> tbItem { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbControle : EntityBase
    {
        [NotNullNotEmpty]
        public virtual int idControle { get; set; }
        [Length(50)]
        public virtual string noCliente { get; set; }
        public virtual DateTime? dtValidade { get; set; }
        public virtual int? stExpira { get; set; }
    }
}

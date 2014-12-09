using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbLogEpc : EntityBase
    {
        public virtual int idLogEpc { get; set; }
        public virtual TbOperacao tbOperacao { get; set; }
        public virtual TbEquipamento tbEquipamento { get; set; }
        public virtual TbUsuario tbUsuario { get; set; }
        public virtual TbLocalidade tbLocalidade { get; set; }
        [NotNullNotEmpty]
        [Length(32)]
        public virtual string codEpc { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthLog { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbLogLote : EntityBase
    {
        public virtual int idLogLote { get; set; }
        public virtual TbOperacao tbOperacao { get; set; }
        public virtual TbEquipamento tbEquipamento { get; set; }
        public virtual TbUsuario tbUsuario { get; set; }
        public virtual TbLocalidade tbLocalidade { get; set; }
        [Length(50)]
        public virtual string noNome { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthLog { get; set; }
    }
}

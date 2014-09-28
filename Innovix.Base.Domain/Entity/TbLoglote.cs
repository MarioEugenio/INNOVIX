using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbLoglote : EntityBase
    {
        public virtual int idLoglote { get; set; }
        public virtual TbLote tbLote { get; set; }
        public virtual TbOperacao tbOperacao { get; set; }
        public virtual TbEquipamento tbEquipamento { get; set; }
        public virtual TbUsuario tbUsuario { get; set; }
        public virtual TbLocalidade tbLocalidade { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthLog { get; set; }
    }
}

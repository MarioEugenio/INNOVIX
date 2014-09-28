using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbSincPerfil : EntityBase
    {
        public virtual TbPerfil tbPerfil { get; set; }
        public virtual TbEquipamento tbEquipamento { get; set; }
        [NotNullNotEmpty]
        [Length(1)]
        public virtual string indEnviado { get; set; }
        public virtual DateTime? dthEnviado { get; set; }
    }
}

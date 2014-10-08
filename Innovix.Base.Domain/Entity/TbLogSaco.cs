using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbLogSaco : EntityBase
    {
        public virtual int idLogSaco { get; set; }
        public virtual TbOperacao tbOperacao { get; set; }
        public virtual TbEquipamento tbEquipamento { get; set; }
        public virtual TbUsuario tbUsuario { get; set; }
        public virtual TbLocalidade tbLocalidade { get; set; }
        [Length(32)]
        public virtual string codBarras { get; set; }
        public virtual DateTime? dthLog { get; set; }
    }
}

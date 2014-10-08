using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbLogUsuario : EntityBase
    {
        public virtual int idLogusuario { get; set; }
        public virtual TbUsuario tbUsuario { get; set; }
        public virtual TbOperacao tbOperacao { get; set; }
        public virtual DateTime? dthLog { get; set; }
    }
}

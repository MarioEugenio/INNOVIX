using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbTipoUsuario : EntityBase
    {
        public TbTipoUsuario() {
			tbUsuario = new List<TbUsuario>();
        }
        [Length(30)]
        public virtual string noDesc { get; set; }
        public virtual IList<TbUsuario> tbUsuario { get; set; }
    }
}

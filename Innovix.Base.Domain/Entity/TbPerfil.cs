using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbPerfil : EntityBase
    {
        public TbPerfil() {
			relPerfilOperacao = new List<RelPerfilOperacao>();
			tbSincPerfil = new List<TbSincPerfil>();
			tbUsuario = new List<TbUsuario>();
        }
        public virtual int idPerfil { get; set; }
        [NotNullNotEmpty]
        [Length(50)]
        public virtual string noDesc { get; set; }
        public virtual IList<RelPerfilOperacao> relPerfilOperacao { get; set; }
        public virtual IList<TbSincPerfil> tbSincPerfil { get; set; }
        public virtual IList<TbUsuario> tbUsuario { get; set; }
    }
}

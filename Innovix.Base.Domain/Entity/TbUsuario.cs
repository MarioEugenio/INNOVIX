using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbUsuario : EntityBase
    {
        public TbUsuario() {
			//relEmpresaUsuario = new List<RelEmpresaUsuario>();
			tbLogUsuario = new List<TbLogUsuario>();
			//tbLogitem = new List<TbLogitem>();
			//tbLoglote = new List<TbLoglote>();
			//tbLogsaco = new List<TbLogsaco>();
			//tbSincUsuario = new List<TbSincUsuario>();
        }
        public virtual TbPerfil tbPerfil { get; set; }
        public virtual TbTipoUsuario tbTipoUsuario { get; set; }
        [NotNullNotEmpty]
        [Length(50)]
        public virtual string noUsuario { get; set; }
        [NotNullNotEmpty]
        public virtual byte[] codSenha { get; set; }

        [NotNullNotEmpty]
        [Length(18)]
        public virtual string codCpfCnpj { get; set; }
        [Length(30)]
        public virtual string noEmail { get; set; }
        [Length(20)]
        public virtual string noTelefone { get; set; }
        //public virtual IList<RelEmpresaUsuario> relEmpresaUsuario { get; set; }
        public virtual IList<TbLogUsuario> tbLogUsuario { get; set; }
        //public virtual IList<TbLogitem> tbLogitem { get; set; }
        //public virtual IList<TbLoglote> tbLoglote { get; set; }
        //public virtual IList<TbLogsaco> tbLogsaco { get; set; }
        //public virtual IList<TbSincUsuario> tbSincUsuario { get; set; }

        public virtual string password { get; set; }
    }
}

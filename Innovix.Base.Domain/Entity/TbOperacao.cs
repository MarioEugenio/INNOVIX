using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbOperacao : EntityBase
    {
        public TbOperacao() {
			//relPerfilOperacao = new List<RelPerfilOperacao>();
			tbLogUsuario = new List<TbLogUsuario>();
			//tbLogitem = new List<TbLogitem>();
			//tbLoglote = new List<TbLoglote>();
			//tbLogsaco = new List<TbLogsaco>();
			//tbSincOperacao = new List<TbSincOperacao>();
        }
        [NotNullNotEmpty]
        [Length(50)]
        public virtual string noDesc { get; set; }
       // public virtual IList<RelPerfilOperacao> relPerfilOperacao { get; set; }
        public virtual IList<TbLogUsuario> tbLogUsuario { get; set; }
        //public virtual IList<TbLogitem> tbLogitem { get; set; }
        //public virtual IList<TbLoglote> tbLoglote { get; set; }
        //public virtual IList<TbLogsaco> tbLogsaco { get; set; }
        //public virtual IList<TbSincOperacao> tbSincOperacao { get; set; }
    }
}

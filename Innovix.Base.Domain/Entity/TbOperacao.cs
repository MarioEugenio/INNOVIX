using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbOperacao : EntityBase
    {
        public TbOperacao() {
			//relPerfilOperacao = new List<RelPerfilOperacao>();
			tbLogEpc = new List<TbLogEpc>();
			tbLogLote = new List<TbLogLote>();
			tbLogSaco = new List<TbLogSaco>();
			tbLogUsuario = new List<TbLogUsuario>();
			//tbSincOperacao = new List<TbSincOperacao>();
        }
        public virtual int idOperacao { get; set; }
        [NotNullNotEmpty]
        [Length(50)]
        public virtual string noDesc { get; set; }
        //public virtual IList<RelPerfilOperacao> relPerfilOperacao { get; set; }
        public virtual IList<TbLogEpc> tbLogEpc { get; set; }
        public virtual IList<TbLogLote> tbLogLote { get; set; }
        public virtual IList<TbLogSaco> tbLogSaco { get; set; }
        public virtual IList<TbLogUsuario> tbLogUsuario { get; set; }
        //public virtual IList<TbSincOperacao> tbSincOperacao { get; set; }
    }
}

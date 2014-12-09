using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbEquipamento : EntityBase
    {
        public TbEquipamento() {
			//relEmpresaEquipamento = new List<RelEmpresaEquipamento>();
            tbLogEpc = new List<TbLogEpc>();
            tbLoglote = new List<TbLogLote>();
            tbLogsaco = new List<TbLogSaco>();
			/*tbSincLocalidade = new List<TbSincLocalidade>();
			tbSincOperacao = new List<TbSincOperacao>();
			tbSincPerfil = new List<TbSincPerfil>();
			tbSincRfid = new List<TbSincRfid>();
			tbSincRota = new List<TbSincRota>();
			tbSincUsuario = new List<TbSincUsuario>();
			tbSincronizacao = new List<TbSincronizacao>();*/
        }
        public virtual TbLocalidade tbLocalidade { get; set; }
        [Length(50)]
        public virtual string noEquipamento { get; set; }
        //public virtual IList<RelEmpresaEquipamento> relEmpresaEquipamento { get; set; }
        public virtual IList<TbLogEpc> tbLogEpc { get; set; }
        public virtual IList<TbLogLote> tbLoglote { get; set; }
        public virtual IList<TbLogSaco> tbLogsaco { get; set; }
        /*public virtual IList<TbSincLocalidade> tbSincLocalidade { get; set; }
        public virtual IList<TbSincOperacao> tbSincOperacao { get; set; }
        public virtual IList<TbSincPerfil> tbSincPerfil { get; set; }
        public virtual IList<TbSincRfid> tbSincRfid { get; set; }
        public virtual IList<TbSincRota> tbSincRota { get; set; }
        public virtual IList<TbSincUsuario> tbSincUsuario { get; set; }
        public virtual IList<TbSincronizacao> tbSincronizacao { get; set; }*/
    }
}

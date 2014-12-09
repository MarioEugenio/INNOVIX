using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbItem : EntityBase
    {
        public TbItem() {
			//relEmpresaItem = new List<RelEmpresaItem>();
			//tbLogitem = new List<TbLogitem>();
			//tbSincronizacao = new List<TbSincronizacao>();
        }
        public virtual TbStatus tbStatus { get; set; }
        public virtual TbRfid tbRfid { get; set; }
        public virtual TbSaco tbSaco { get; set; }
        public virtual TbLote tbLote { get; set; }
        public virtual TbLocalidade tbLocalidade { get; set; }
        public virtual TbLocalidade tbLocalidadeDestino { get; set; }
        [Length(50)]
        public virtual string codBarras { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime dthCriacao { get; set; }
        [Length(100)]
        public virtual string noDesc { get; set; }
        //public virtual IList<RelEmpresaItem> relEmpresaItem { get; set; }
        //public virtual IList<TbLogitem> tbLogitem { get; set; }
        //public virtual IList<TbSincronizacao> tbSincronizacao { get; set; }
    }
}

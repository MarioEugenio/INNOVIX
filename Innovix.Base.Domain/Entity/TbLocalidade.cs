using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbLocalidade : EntityBase
    {
        public TbLocalidade() {
			//relLocalidadeRota = new List<RelLocalidadeRota>();
			tbEquipamento = new List<TbEquipamento>();
            tbItemDestino = new List<TbItem>();
			tbItem = new List<TbItem>();
			//tbLogitem = new List<TbLogitem>();
			//tbLoglote = new List<TbLoglote>();
			//tbLogsaco = new List<TbLogsaco>();
			//tbLote = new List<TbLote>();
			//tbLote = new List<TbLote>();
        }
        [Length(50)]
        public virtual string noDesc { get; set; }
        [Length(50)]
        public virtual string noNome { get; set; }
        [Length(50)]
        public virtual string noCidade { get; set; }
        [Length(13)]
        public virtual string noTelefone { get; set; }
        [Length(50)]
        public virtual string noResponsavel { get; set; }
        [Length(2)]
        public virtual string noEstado { get; set; }
        //public virtual IList<RelLocalidadeRota> relLocalidadeRota { get; set; }
        public virtual IList<TbEquipamento> tbEquipamento { get; set; }
        public virtual IList<TbItem> tbItemDestino { get; set; }
        public virtual IList<TbItem> tbItem { get; set; }
        //public virtual IList<TbLogitem> tbLogitem { get; set; }
        //public virtual IList<TbLoglote> tbLoglote { get; set; }
        //public virtual IList<TbLogsaco> tbLogsaco { get; set; }
        //public virtual IList<TbLote> tbLote { get; set; }
        //public virtual IList<TbLote> tbLote { get; set; }
    }
}

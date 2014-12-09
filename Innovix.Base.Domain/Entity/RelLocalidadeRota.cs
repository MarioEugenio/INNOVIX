using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class RelLocalidadeRota : EntityBase
    {
        public virtual int idLocalidade { get; set; }
        public virtual int idRota { get; set; }
        public virtual TbLocalidade tbLocalidade { get; set; }
        public virtual TbRota tbRota { get; set; }
        [NotNullNotEmpty]
        public virtual int intCheckpoint { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
            var t = obj as RelLocalidadeRota;
			if (t == null) return false;
			if (idLocalidade == t.idLocalidade
			 && idRota == t.idRota)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ idLocalidade.GetHashCode();
			hash = (hash * 397) ^ idRota.GetHashCode();

			return hash;
        }
        #endregion
    }
}

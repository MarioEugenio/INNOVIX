using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class RelPerfilOperacao : EntityBase
    {
        public virtual int idPerfil { get; set; }
        public virtual int idOperacao { get; set; }
        public virtual TbPerfil tbPerfil { get; set; }
        public virtual TbOperacao tbOperacao { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as RelPerfilOperacao;
			if (t == null) return false;
			if (idPerfil == t.idPerfil
			 && idOperacao == t.idOperacao)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ idPerfil.GetHashCode();
			hash = (hash * 397) ^ idOperacao.GetHashCode();

			return hash;
        }
        #endregion
    }
}

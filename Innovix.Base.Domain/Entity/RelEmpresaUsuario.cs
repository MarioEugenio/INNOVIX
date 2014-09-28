using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class RelEmpresaUsuario : EntityBase
    {
        public virtual int idEmpresa { get; set; }
        public virtual int idUsuario { get; set; }
        public virtual TbEmpresa tbEmpresa { get; set; }
        public virtual TbUsuario tbUsuario { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
            var t = obj as RelEmpresaUsuario;
			if (t == null) return false;
			if (idEmpresa == t.idEmpresa
			 && idUsuario == t.idUsuario)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ idEmpresa.GetHashCode();
			hash = (hash * 397) ^ idUsuario.GetHashCode();

			return hash;
        }
        #endregion
    }
}

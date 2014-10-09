using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbSincUsuario : EntityBase
    {
        public virtual int idUsuario { get; set; }
        public virtual int idEquipamento { get; set; }

        public virtual TbUsuario tbUsuario { get; set; }
        public virtual TbEquipamento tbEquipamento { get; set; }
        [NotNullNotEmpty]
        [Length(1)]
        public virtual string indEnviado { get; set; }
        public virtual DateTime dthEnviado { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as TbSincUsuario;
            if (t == null) return false;
            if (idUsuario == t.idUsuario
             && idEquipamento == t.idEquipamento)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ idUsuario.GetHashCode();
            hash = (hash * 397) ^ idEquipamento.GetHashCode();

            return hash;
        }
        #endregion
    }
}

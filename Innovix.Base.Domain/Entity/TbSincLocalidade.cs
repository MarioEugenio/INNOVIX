using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {
    
    public class TbSincLocalidade : EntityBase {
        public virtual int idLocalidade { get; set; }
        public virtual int idEquipamento { get; set; }
        public virtual TbLocalidade tbLocalidade { get; set; }
        public virtual TbEquipamento tbEquipamento { get; set; }
        [NotNullNotEmpty]
        [Length(1)]
        public virtual string indEnviado { get; set; }
        public virtual DateTime? dthEnviado { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as TbSincLocalidade;
            if (t == null) return false;
            if (idLocalidade == t.idLocalidade
             && idEquipamento == t.idEquipamento)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ idLocalidade.GetHashCode();
            hash = (hash * 397) ^ idEquipamento.GetHashCode();

            return hash;
        }
        #endregion
    }
}
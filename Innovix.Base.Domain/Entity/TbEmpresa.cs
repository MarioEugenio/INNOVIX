using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Innovix.Base.Domain.Entity {

    public class TbEmpresa : EntityBase
    {
        public TbEmpresa() {
			relEmpresaEquipamento = new List<RelEmpresaEquipamento>();
			relEmpresaItem = new List<RelEmpresaItem>();
			relEmpresaUsuario = new List<RelEmpresaUsuario>();
        }
        public virtual int idEmpresa { get; set; }
        [NotNullNotEmpty]
        [Length(50)]
        public virtual string noEmpresa { get; set; }
        [Length(200)]
        public virtual string noDesc { get; set; }
        [Length(100)]
        public virtual string noEndereco { get; set; }
        [Length(15)]
        public virtual string noTelefone { get; set; }
        public virtual IList<RelEmpresaEquipamento> relEmpresaEquipamento { get; set; }
        public virtual IList<RelEmpresaItem> relEmpresaItem { get; set; }
        public virtual IList<RelEmpresaUsuario> relEmpresaUsuario { get; set; }
    }
}

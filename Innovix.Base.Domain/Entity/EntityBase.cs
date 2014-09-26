using Innovix.Base.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innovix.Base.Domain.Entity
{
    public abstract class EntityBase
    {
        protected Dictionary<Func<object, object>, string> CamposVazios { get; set; }

        public EntityBase()
        {
            CamposVazios = new Dictionary<Func<object, object>, string>();
        }

        public virtual void ValidarSalvar()
        {
            if (CamposVazios.Any())
            {
                throw new ExceptionRequired(CamposVazios);
            }
        }

        public virtual void ValidarExclusao() { }

        public virtual int Id
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //"Mimo" para ver os objetos de maneira mais amigável ao debugar :)
        public override string ToString()
        {
            string descritor = ObterDescritor();

            if (string.IsNullOrEmpty(descritor))
                descritor = string.Concat("[", base.ToString().Split('.').Last(), "]");

            return string.Format("{0} - {1}", Id, descritor);
        }

        private string ObterDescritor()
        {
            var propriedadeDescritora = this.GetType()
                .GetProperties()
                .Where(x => x.Name.Equals("Nome") || x.Name.Equals("Descricao") || x.Name.Equals("Codigo"))
                .OrderBy(x => x.Name)
                .LastOrDefault();

            if (propriedadeDescritora != null)
            {
                var valor = propriedadeDescritora.GetValue(this, null) as string;
                return valor ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innovix.Base.Infrastructure.Exceptions
{
    public class ExceptionRequired : Exception
    {
        private Dictionary<Func<object, object>, string> camposVazios;

        public ExceptionRequired(Dictionary<Func<object, object>, string> camposVazios)
            : base(PrepararMensagem(camposVazios))
        {
            this.camposVazios = camposVazios;
        }

        private static string PrepararMensagem(Dictionary<Func<object, object>, string> camposVazios)
        {
            return string.Join("<br/>", camposVazios.Select(x => x.Value).ToArray());
        }
    }
}
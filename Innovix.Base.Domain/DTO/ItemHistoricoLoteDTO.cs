using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innovix.Base.Domain.DTO
{
    public class ItemHistoricoLoteDTO
    {
        public string Localidade;
        public DateTime Data;
        public int TotalItensLidos;
        public string Operador;
        public int IDLOTE;
        public int IDLOCALIDADE;
    }
}
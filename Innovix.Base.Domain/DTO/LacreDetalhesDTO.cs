using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innovix.Base.Domain.DTO
{
    public class LacreDetalhesDTO
    {
        public string Lacre;
        public DateTime DataCadastro;
        public string Embarque;
        public string Origem;
        public string Destino;
        public int TotalItens;
        public int TotalItensEntregues;
        public string Status;
        public DateTime UltimaAtualizacao;
        public string UltimaLocalidade;
    }
}
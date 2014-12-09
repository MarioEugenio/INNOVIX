using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innovix.Base.Domain.DTO
{
    public class LoteDetalhesDTO
    {
        public string Embarque;
        public string Origem;
        public string Destino;
        public string Status;
        public string DataCadastro;
        public int TotalSacos;
        public int TotalItens;
        public int TotalItensEntregues;
        public string UltimaAtualizacao;
        public string UltimaLocalidade;
    }
}
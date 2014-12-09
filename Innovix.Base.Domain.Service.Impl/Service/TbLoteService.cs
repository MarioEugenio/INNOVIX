using System;
using System.Collections.Generic;
using System.Linq;
using Innovix.Base.Domain.Entity;
using Innovix.Base.Domain.Service.Impl.Service;
using Innovix.Base.Domain.Service;
using Innovix.Base.Domain.Repository;
using Innovix.Base.Domain.DTO;

namespace Innovix.Base.Domain.Service.Impl
{ 
    public class TbLoteService : ServiceCRUD<TbLote>, ITbLoteService
    {
        ITbLoteRepository repository;

		public TbLoteService(ITbLoteRepository repository) : base(repository) {
            this.repository = repository;
        }

        public List<LoteDTO> GetLotes()
        {
            return this.repository.GetLotes();
        }

        public List<LacreDetalhesDTO> GetLoteDetalhes(int id)
        {
            return this.repository.GetLoteDetalhes(id);
        }
	}
}
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
    public class TbLacreService : ServiceCRUD<TbLacre>, ITbLacreService
    {
        private ITbLacreRepository repository;

		public TbLacreService(ITbLacreRepository repository) : base(repository) {
            this.repository = repository;
        }

        public List<LacreDTO> GetLacres()
        {
            return this.repository.GetLacres();
        }

        public List<LacreDetalhesDTO> GetItemDetalhes(int id)
        {
            return this.repository.GetItemDetalhes(id);
        }
	}
}
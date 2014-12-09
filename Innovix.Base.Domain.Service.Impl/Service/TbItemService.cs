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
    public class TbItemService : ServiceCRUD<TbItem>, ITbItemService
    {
        private ITbItemRepository repository;

		public TbItemService(ITbItemRepository repository) : base(repository) {
            this.repository = repository;
        }

        public List<ItemDTO> GetItems()
        {
            return this.repository.GetItems();
        }

        public List<ItemDetalhesDTO> GetItemDetalhes(int id)
        {
            return this.repository.GetItemDetalhes(id);
        }

        public List<ItemLacreDTO> GetItemLacre(int id)
        {
            return this.repository.GetItemLacre(id);
        }

        public List<ItemLoteDTO> GetItemLote(int id)
        {
            return this.repository.GetItemLote(id);
        }

        public List<ItemHistoricoDTO> GetItemHistorico(int id)
        {
            return this.repository.GetItemHistorico(id);
        }

        public List<ItemHistoricoLoteDTO> GetItemHistoricoLote(int id)
        {
            return this.repository.GetItemHistoricoLote(id);
        }
	}
}
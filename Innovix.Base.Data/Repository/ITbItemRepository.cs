using Innovix.Base.Data.Repository;
using Innovix.Base.Domain.DTO;
using Innovix.Base.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Innovix.Base.Domain.Repository
{ 
    public interface ITbItemRepository : IRepository<TbItem>
    {
        List<ItemDTO> GetItems();

        List<ItemDetalhesDTO> GetItemDetalhes(int id);

        List<ItemLacreDTO> GetItemLacre(int id);

        List<ItemLoteDTO> GetItemLote(int id);

        List<ItemHistoricoDTO> GetItemHistorico(int id);

        List<ItemHistoricoLoteDTO> GetItemHistoricoLote(int id);
	}
}
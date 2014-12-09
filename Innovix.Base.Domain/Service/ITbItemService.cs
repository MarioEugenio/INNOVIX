using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Innovix.Base.Domain.Entity;
using System.Linq.Expressions;
using Innovix.Base.Domain.DTO;

namespace Innovix.Base.Domain.Service
{ 
    public interface ITbItemService : IServiceCRUD<TbItem>
    {
        List<ItemDTO> GetItems();

        List<ItemDetalhesDTO> GetItemDetalhes(int id);

        List<ItemLacreDTO> GetItemLacre(int id);

        List<ItemLoteDTO> GetItemLote(int id);

        List<ItemHistoricoDTO> GetItemHistorico(int id);

        List<ItemHistoricoLoteDTO> GetItemHistoricoLote(int id);
	}
}
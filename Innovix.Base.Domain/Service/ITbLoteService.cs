using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Innovix.Base.Domain.Entity;
using System.Linq.Expressions;
using Innovix.Base.Domain.DTO;

namespace Innovix.Base.Domain.Service
{ 
    public interface ITbLoteService : IServiceCRUD<TbLote>
    {
        List<LoteDTO> GetLotes();

        List<LacreDetalhesDTO> GetLoteDetalhes(int id);
	}
}
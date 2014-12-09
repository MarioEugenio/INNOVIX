using Innovix.Base.Data.Repository;
using Innovix.Base.Domain.DTO;
using Innovix.Base.Domain.Entity;
using System.Collections.Generic;

namespace Innovix.Base.Domain.Repository
{ 
    public interface ITbLoteRepository : IRepository<TbLote>
    {
        List<LoteDTO> GetLotes();

        List<LacreDetalhesDTO> GetLoteDetalhes(int id);
	}
}
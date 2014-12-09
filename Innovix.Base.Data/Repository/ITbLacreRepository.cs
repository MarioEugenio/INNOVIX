using Innovix.Base.Data.Repository;
using Innovix.Base.Domain.DTO;
using Innovix.Base.Domain.Entity;
using System.Collections.Generic;

namespace Innovix.Base.Domain.Repository
{ 
    public interface ITbLacreRepository : IRepository<TbLacre>
    {
        List<LacreDTO> GetLacres();

        List<LacreDetalhesDTO> GetItemDetalhes(int id);
	}
}
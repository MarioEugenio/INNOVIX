using Innovix.Base.Data.Repository;
using Innovix.Base.Domain.DTO;
using Innovix.Base.Domain.Entity;
using System.Collections.Generic;

namespace Innovix.Base.Domain.Repository
{ 
    public interface ITbUsuarioRepository : IRepository<TbUsuario>
    {
        IEnumerable<TbUsuario> GetHashAuth(string password);

        List<LogOperador> GetLogOperador();
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Innovix.Base.Domain.Entity;
using System.Linq.Expressions;
using Innovix.Base.Domain.DTO;

namespace Innovix.Base.Domain.Service
{ 
    public interface ITbUsuarioService : IServiceCRUD<TbUsuario>
    {
        byte[] GetHashAuth(string password);

        List<LogOperador> GetLogOperador();
	}
}
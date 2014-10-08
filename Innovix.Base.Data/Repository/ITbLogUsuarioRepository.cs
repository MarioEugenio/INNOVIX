using Innovix.Base.Data.Repository;
using Innovix.Base.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Innovix.Base.Domain.Repository
{ 
    public interface ITbLogUsuarioRepository : IRepository<TbLogUsuario>
    {
         IList<TbLogUsuario> GetLogUsuario(DateTime dtAction, string search);
	}
}
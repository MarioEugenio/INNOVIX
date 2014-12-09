using System;
using System.Collections.Generic;
using System.Linq;
using Innovix.Base.Domain.Entity;
using Innovix.Base.Domain.Service.Impl.Service;
using Innovix.Base.Domain.Service;
using Innovix.Base.Domain.Repository;

namespace Innovix.Base.Domain.Service.Impl
{ 
    public class TbLogUsuarioService : ServiceCRUD<TbLogUsuario>, ITbLogUsuarioService
    {
        ITbLogUsuarioRepository repository;

		public TbLogUsuarioService(ITbLogUsuarioRepository repository) : base(repository) {
            this.repository = repository;
        }

        public IList<TbLogUsuario> GetLogUsuario(DateTime dtAction, string search)
        {
            return repository.GetLogUsuario(dtAction, search);
        }
	}
}
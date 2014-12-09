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
    public class TbUsuarioService : ServiceCRUD<TbUsuario>, ITbUsuarioService
    {
        ITbUsuarioRepository repository;

		public TbUsuarioService(ITbUsuarioRepository repository) : base(repository) {
            this.repository = repository;
        }

        public byte[] GetHashAuth(string password)
        {
            var list = this.repository.GetHashAuth(password).ToList();
            return list.SingleOrDefault().codSenha;
        }

        public List<LogOperador> GetLogOperador()
        {
            return this.repository.GetLogOperador();
        }
	}
}
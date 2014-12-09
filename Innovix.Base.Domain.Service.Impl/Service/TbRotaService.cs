using System;
using System.Collections.Generic;
using System.Linq;
using Innovix.Base.Domain.Entity;
using Innovix.Base.Domain.Service.Impl.Service;
using Innovix.Base.Domain.Service;
using Innovix.Base.Domain.Repository;

namespace Innovix.Base.Domain.Service.Impl
{ 
    public class TbRotaService : ServiceCRUD<TbRota>, ITbRotaService
    {
		public TbRotaService(ITbRotaRepository repository) : base(repository) { }
	}
}
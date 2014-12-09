using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innovix.Base.Domain.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
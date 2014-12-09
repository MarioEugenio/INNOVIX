using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innovix.Base.Infrastructure.Exceptions
{
    public class ExceptionService : Exception 
    {
        public ExceptionService(Exception exception)
            : base(exception.Message, exception)
        {
        
        }

        public ExceptionService(string message) : base(message) { }
    }
}
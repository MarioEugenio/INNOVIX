using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Innovix.Base.Infrastructure.Log
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExceptionLogAttribute : Attribute
    {
        public string Message { get; set; }

        public ExceptionLogAttribute(string message, string funcionalidade)
        {
            this.Message = message;
        }
    }
}

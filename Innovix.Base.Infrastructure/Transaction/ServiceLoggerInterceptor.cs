using System;
using System.Transactions;
using Castle.DynamicProxy;
using System.Collections;
using System.Web;
using System.Linq;
using NHibernate;
using Innovix.Base.Infrastructure.Exceptions;

namespace Itamaraty.Nucleo.Infraestrutura.Transacoes 
{
    public class ServiceLoggerInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ISession db;
        private ITransaction transaction = null;

        public ServiceLoggerInterceptor(ISession db)
        {
            this.db = db;
        }

        public void Intercept(IInvocation invocation)
        {

            bool iAmTheFirst = false;

            if (transaction == null)
            {
                transaction = db.BeginTransaction();
                iAmTheFirst = true;
            }

            try
            {
                invocation.Proceed();

                if (iAmTheFirst)
                {
                    iAmTheFirst = false;

                    transaction.Commit();
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                if (iAmTheFirst)
                {
                    iAmTheFirst = false;

                    transaction.Rollback();
                    db.Clear();
                    transaction = null;
                }

                throw new ExceptionService(ex);
            }

            invocation.Proceed();
        }

    }
    
}

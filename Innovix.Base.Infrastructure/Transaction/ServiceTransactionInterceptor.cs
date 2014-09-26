using System;
using System.Transactions;
using Castle.DynamicProxy;
using System.Collections;
using NHibernate;
using Innovix.Base.Infrastructure.Exceptions;

namespace Itamaraty.Nucleo.Infraestrutura.Transacoes
{
    public class ServiceTransactionInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ISession db;
        private ITransaction transaction = null;

        public ServiceTransactionInterceptor(ISession db)
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
                if (iAmTheFirst)
                {
                    iAmTheFirst = false;

                    transaction.Rollback();
                    db.Clear();
                    transaction = null;
                }

                throw new ExceptionService(ex);
            }
        }
        
    }
}

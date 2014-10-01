using NHibernate;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Type;
using System.Diagnostics;
using System;
using System.Xml;
using System.Web;

namespace Innovix.Base.Infrastructure.Transaction
{
    /// <summary>
    /// Interceptor para gerar LOG das transações feitas com os registros de
    /// banco de dados manipulados pelo NHibernate.
    /// </summary>
    public class NHibernateInterceptor : EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            Trace.WriteLine(sql.ToString());
            return sql;
        }
    }
}
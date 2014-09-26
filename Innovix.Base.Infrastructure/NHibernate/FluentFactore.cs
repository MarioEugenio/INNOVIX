using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;


namespace Innovix.Base.Infrastructure.NHibernate
{
    public class FluentSessionFactoryFactory
    {
        public static ISessionFactory GetSessionFactory(string currentSessionContextClass, string connectionStringKey)
        {
            return Fluently.Configure().Database(
                                           MsSqlConfiguration
                                           .MsSql2008
                                           .ShowSql()
                                           .ConnectionString(c => c.FromConnectionStringWithKey(connectionStringKey)))
                                       .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(FluentSessionFactoryFactory).Assembly))
                                       .ExposeConfiguration(x => x.SetProperty(Environment.CurrentSessionContextClass, currentSessionContextClass))
                                       .Cache(x => x.UseQueryCache())
                //.Cache(x => x.UseSecondLevelCache().ProviderClass<SysCacheProvider>())
                                       .BuildSessionFactory();
        }

    }
}
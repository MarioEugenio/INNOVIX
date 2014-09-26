using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Innovix.Base.Infrastructure.NHibernate;
using Innovix.Base.Infrastructure.Transaction;
using Itamaraty.Nucleo.Infraestrutura.Transacoes;
using Innovix.Base.Domain.Service.Impl.Service;
using Innovix.Base.Persistencia.NHibernate.Repository;
using Innovix.Base.Domain.Entity;


namespace Innovix.Base.Web.Init
{
    public class ContainerHelper
    {
        public static ContainerBuilder ObterContainerBuilder()
        {
            //Inicializar o container
            var builder = new ContainerBuilder();

            builder.Register(x => FluentSessionFactoryFactory.GetSessionFactory("thread_static", "psConnection")).SingleInstance();

            builder.RegisterType<NHibernateInterceptor>().SingleInstance().AsSelf();

            builder.Register(x =>
            {
                var session = x.Resolve<ISessionFactory>().OpenSession(x.Resolve<NHibernateInterceptor>());
                session.FlushMode = FlushMode.Commit;
                return session;
            })
            .InstancePerHttpRequest()
            .OnRelease(x =>
            {
                x.Dispose();
            });

            // Registrando no container os repositórios implementados com NHibernate
            var dataAccess = typeof(RepositorioNHibernate<>).Assembly;
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();


            // Registrando no container os Serviços e seus interceptadores
            var servicos = typeof(ServiceCRUD<>).Assembly;
            builder.RegisterAssemblyTypes(servicos)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(ServiceTransactionInterceptor));

            var servicosNonCrud = typeof(ServiceImpl).Assembly;
            builder.RegisterAssemblyTypes(servicosNonCrud)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(ServiceTransactionInterceptor));


            builder.RegisterType<ServiceTransactionInterceptor>()
                .InstancePerHttpRequest()
                .AsSelf();

            //Registra as entidades no container pelo seu próprio tipo concreto
            //Registrando no container as entidades
            var entidades = typeof(EntityBase).Assembly;
            builder.RegisterAssemblyTypes(entidades)
                .Where(t => t.BaseType == typeof(EntityBase))
                .AsSelf();

            return builder;

        }
    }
}
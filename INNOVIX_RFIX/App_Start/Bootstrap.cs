using Autofac.Integration.Mvc;
using INNOVIX_RFIX.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.WebApi;


using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Http;

namespace INNOVIX_RFIX.App_Start
{
    public class Bootstrap
    {
         public static void Run()
        {
            RegisterContainer();
        }

        private static void RegisterContainer()
        {
            //Inicializar o container
            var builder = Innovix.Base.Web.Init.ContainerHelper.ObterContainerBuilder();

            //Registra os controllers no container pelo seu próprio tipo concreto
            // Registrando no container os controllers
            var controllers = typeof(HomeController).Assembly;
            builder.RegisterAssemblyTypes(controllers)
                .Where(t => t.Namespace == "INNOVIX_RFIX.Controllers")
                .AsSelf();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            container.Resolve<ISessionFactory>();

            System.Web.HttpContext.Current.Application["DependencyResolver"] = DependencyResolver.Current;

            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
        }
    }
}
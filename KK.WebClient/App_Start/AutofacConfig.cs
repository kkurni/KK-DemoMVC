using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using KK.WebClient.Areas.oldCar.Controllers;

namespace KK.WebClient
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register MVC 4 Contrrollers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            //register Domain Depedencies
            builder.RegisterModule(new Domain.AutofacModule());

            // Build the container.
            var container = builder.Build();

            // SET Web API resolver
            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);
            // Configure Web API with the dependency resolver.
            config.DependencyResolver = resolver;

            //set MVC4 resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using KK.Domain.Repositories.Interfaces;
using KK.Domain.Services.Interfaces;

namespace KK.Domain
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigureRepositoriesDependencies(builder);
            ConfigureServicesDependencies(builder);
        }

        private void ConfigureServicesDependencies(ContainerBuilder builder)
        {
            // Register other dependencies.
            builder.RegisterAssemblyTypes(typeof(IServices).Assembly)
                .Where(x => typeof(IServices).IsAssignableFrom(x))
                .AsImplementedInterfaces();
                //.InstancePerApiRequest();


            //if you want to use dynamic proxy to intercept the service  e.g mini progiler
            //.EnableInterfaceInterceptors() 
            //.InterceptedBy(typeof(CallProfiler));
        }

        private void ConfigureRepositoriesDependencies(ContainerBuilder builder)
        {
            // Register other dependencies.
            builder.RegisterAssemblyTypes(typeof(IRepositories).Assembly)
              .Where(x => typeof(IRepositories).IsAssignableFrom(x))
              .AsImplementedInterfaces();
              //.InstancePerApiRequest();
        }
    }
}

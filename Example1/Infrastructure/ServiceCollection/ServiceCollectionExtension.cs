using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Project.Manager.InterfaceDeclaration;
using Project.Manager.InterfaceImplemntation;

namespace Example1.Infrastructure.ServiceCollection
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// you can add service collection root
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddDepdancies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IModuleInterface>(serviceProvidor =>
            {
                var httpaccesor= serviceProvidor.GetRequiredService<IHttpContextAccessor>();
                //you will add your codition function anything factory 
                //here you can use any kind of fucntion or condition
                if (httpaccesor.HttpContext.Request.QueryString.HasValue)
                {
                    return new Stretargy1();
                }
                else
                {
                    return  new Stretargy2();
                }

            });
        }
    }
}

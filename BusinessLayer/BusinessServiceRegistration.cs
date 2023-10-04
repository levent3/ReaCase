using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class BusinessServiceRegistration
    {


        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {

            services.AddScoped<IKullaniciManager, KullaniciManager>();
            services.AddScoped<ITrenSeferManager, TrenSeferManager>();
            services.AddScoped<ITrenIstasyonManager, TrenIstasyonManager>();


            return services;
        }
    }
}

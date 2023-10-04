using DataLayer.Abstract;
using DataLayer.Concreate;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class DataAccessServiceRegistration
    {

        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("SqlDbContext"));
            });


            services.AddScoped<IKullaniciDal, KullaniciDAL>();
            services.AddScoped<ITrenSeferDal, TrenSeferDAL>();
            services.AddScoped<ITrenIstasyonDal, TrenIstasyonDAL>();
      

            return services;
        }



    }
}

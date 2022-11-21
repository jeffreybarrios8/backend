using CentroEstetica.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroEstetica
{
    public class Startup
    {
        private readonly string Cors="MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<DataAccessInterface.IServicios, DataAccess.Servicios>();
            services.AddSingleton<LogicInterface.IServicios, Logic.Servicios>();
            services.AddSingleton<DataAccessInterface.IEmpleado, DataAccess.Empleado>();
            services.AddSingleton<LogicInterface.IEmpleado, Logic.Empleado>();
            services.AddSingleton<DataAccessInterface.ICliente, DataAccess.Cliente>();
            services.AddSingleton<LogicInterface.ICliente, Logic.Cliente>();
            services.AddSingleton<DataAccessInterface.IReservacion, DataAccess.Reservacion>();
            services.AddSingleton<LogicInterface.IReservacion, Logic.Reservacion>();
            services.AddSingleton<DataAccessInterface.IDetalleReservacion, DataAccess.DetalleReservacion>();
            services.AddSingleton<LogicInterface.IDetalleReservacion, Logic.DetalleReservacion>();
            services.AddSingleton<DataAccessInterface.IUsuario, DataAccess.Usuario>();
            services.AddSingleton<BusinessLogicInterface.IUsuario, BusinessLogic.Usuario>();


            services.AddCors(option =>
            {
                option.AddPolicy(name: Cors, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(Cors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go.Aplicacion;
using Go.Interfaces.Aplicacion;
using Go.Interfaces.Data;
using Go.Interfaces.Dominio;
using Go.Juegos.Data;
using Go.Juegos.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Go.Juegos.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddDbContext<JuegoContexto>(opciones =>
                                                 opciones.UseSqlite(Configuration.GetConnectionString("sqlLite")));

            services.AddScoped<IJuegoRepo, JuegoRepo>();
            services.AddScoped<IPuntoRepo, PuntoRepo>();

            services.AddScoped<IJugada, Jugada>();

            services.AddScoped<IJuegoIniciador, JuegoIniciador>();
            services.AddScoped<IPartida, Partida>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

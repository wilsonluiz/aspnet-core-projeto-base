using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Template.Api.Dominio.Interfaces;
using Template.Api.Infraestrutura.Dados;
using Template.Api.Infraestrutura.Dados.Repositorios;

namespace Template.Api
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
            services.AddScoped<ContextoTemplate>();

            services.AddScoped(typeof(IRepositorioBase<,>), typeof(RepositorioBase<,>));
            services.AddScoped(typeof(IRepositorioBaseSomenteLeitura<,>), typeof(RepositorioBaseSomenteLeitura<,>));

            // services.AddSingleton<IConfiguration>(Configuration);

            var conn = Configuration.GetConnectionString("ContextoTemplate");

            services.AddDbContext<ContextoTemplate>(options => options.UseSqlServer(conn));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

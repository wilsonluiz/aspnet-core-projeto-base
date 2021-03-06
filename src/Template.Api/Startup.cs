﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Template.Api.Dominio.Entidades.ControleAcesso;
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
            services.AddIdentity<Usuario, Perfil>(config =>
            {
                config.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<ContextoTemplate>();


            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };
                });

            services.AddAuthorization(config => 
            {
                config.AddPolicy("ObrigatorioPerfilAdmin", builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole("Admin");
                });
            });

            services.AddScoped(typeof(IRepositorioBase<,>), typeof(RepositorioBase<,>));
            services.AddScoped(typeof(IRepositorioBaseSomenteLeitura<,>), typeof(RepositorioBaseSomenteLeitura<,>));

            // services.AddSingleton<IConfiguration>(Configuration);

            var conn = Configuration.GetConnectionString("ContextoTemplate");

            services.AddDbContext<ContextoTemplate>(options => options.UseSqlServer(conn));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}

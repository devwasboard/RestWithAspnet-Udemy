using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using RestWithAspnet_Udemy.Model.Context;
using RestWithAspnet_Udemy.Business.Implimentation;
using RestWithAspnet_Udemy.Business;
using RestWithAspnet_Udemy.Repository;
using RestWithAspnet_Udemy.Repository.Implimentation;



using System;
using System.Collections.Generic;
using RestWithAspnet_Udemy.Repository.Generic;

namespace RestWithAspnet_Udemy
{
    public class Startup
    {
       

        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        //Not erase data when to run migrations
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {

                    _logger.LogCritical("Database migration failed", ex.Message);
                    throw;
                }
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            //Configure version Api -> https://github.com/microsoft/aspnet-api-Versioning/wiki/Versioning-via-the-URL-Path
            services.AddApiVersioning(opttion => opttion.ReportApiVersions = true);

            //Dependency injection
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositorympl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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

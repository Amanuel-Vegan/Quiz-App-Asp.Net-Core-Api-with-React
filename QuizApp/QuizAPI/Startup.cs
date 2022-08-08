using BussinessLogic.IRepository;
using BussinessLogic.Repository;
using DataAccess;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql;
using System;

namespace QuizAPI
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
            AddDbContext(services);
            services.AddControllers();
            services.AddScoped<IRepository<Questions>, QuestionRepository>();
            services.AddScoped<IRepository<Participant>, ParticipantRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuizAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuizAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddDbContext(IServiceCollection services)
        {
            const string DBMS_SQL_SERVER = "SQLServer";
            const string DBMS_POSTGRES = "Postgres";

            var databaseType = Configuration["AppSettings:Database:Driver"];
            var connectionString = Configuration["AppSettings:Database:ConnectionString"];
            var user = Configuration["AppSettings:Database:UserName"];
            var password = Configuration["AppSettings:Database:Password"];

            if (DBMS_SQL_SERVER.Equals(databaseType, StringComparison.OrdinalIgnoreCase))
            {
                var builder = new SqlConnectionStringBuilder(connectionString);

                if (!string.IsNullOrWhiteSpace(password))
                    builder.Password = password;

                if (!string.IsNullOrWhiteSpace(user))
                    builder.UserID = user;

                services.AddDbContext<AppDbContext>(
                    options => options.UseSqlServer(
                        builder.ConnectionString,
                        x => x.MigrationsHistoryTable(AppDbContext.SchemaTableName)
                    )
                );
            }
            else if (DBMS_POSTGRES.Equals(databaseType, StringComparison.OrdinalIgnoreCase))
            {
                var builder = new NpgsqlConnectionStringBuilder(connectionString);

                if (!string.IsNullOrWhiteSpace(user))
                    builder.Username = user;

                if (!string.IsNullOrWhiteSpace(password))
                    builder.Password = password;

                services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(
                builder.ConnectionString,
                 x => x.MigrationsHistoryTable(AppDbContext.SchemaTableName)
                    )
                );
            }
        }
    }
}

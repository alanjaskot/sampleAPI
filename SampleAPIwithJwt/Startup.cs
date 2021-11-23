using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SampleAPIwithJwt.Context.Implenetation;
using SampleAPIwithJwt.Context.Interaface;
using SampleAPIwithJwt.Jwt;
using SampleAPIwithJwt.Repos.Figure;
using SampleAPIwithJwt.Repos.Permits;
using SampleAPIwithJwt.Repos.User;
using SampleAPIwithJwt.Services.Figure;
using SampleAPIwithJwt.Services.Permits;
using SampleAPIwithJwt.Services.Users;
using SampleAPIwithJwt.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace SampleAPIwithJwt
{
    public class Startup
    {
        public static IContainer Container { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDataBaseContext>(opt =>
            {
                string dbFileName = "database.db";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                var _db = Path.Combine(path, dbFileName);

                opt.UseSqlite($"Data source = {_db}");
            });

            services.AddScoped<IAppDataBaseContext, AppDataBaseContext>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPermitsRepo, PermitsRepo>();
            services.AddScoped<IFigureRepo, FigureRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPermitService, PermitService>();
            services.AddScoped<IFigureService, FigureService>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:5001")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            /*services.AddSession(options =>
            {
            });*/


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Proste.API",
                    Description = "Api do zarz¹dzania u¿ytkownikami",
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' (space) and then your token in the text input below.\r\n\r\nExample: \"Bearer tokenValue\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.ApiKey,
                        },
                        new List<string>()
                    }
                });
            });

            services.AddJwt();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            AppDataBaseContext dataBaseContext)
        {
            app.UseStaticFiles();
            app.UseForwardedHeaders();
            app.UseHsts();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json"; // uwaga bez ukosnika
            });

            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);

                c.RoutePrefix = "swagger"; // uwaga bez ukoscnia

                // tu juz z ukosnikiem
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test RESTAPI");
            });

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Console.WriteLine("Migration start");
            dataBaseContext.Database.Migrate();
            Console.WriteLine("Migration end");

            // autofac masz ?? 
            //widzialem, ze jest zainstalowany, sam tego nie robilem
            var builder = new ContainerBuilder();

            var assembliy = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembliy)
                  .AsImplementedInterfaces();

            builder
                .RegisterType<AppDataBaseContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UserService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<PermitService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            Container = builder.Build();
        }
    }
}

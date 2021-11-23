using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SampleAPIwithJwt.Jwt.Interface;
using SampleAPIwithJwt.Jwt.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Jwt
{
    public static class JwtResponse
    {
        public static void AddJwt(this IServiceCollection services)
        {
            IConfiguration configuration;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var jwtSection = configuration.GetSection("jwt");
            services.Configure<JwtOptions>(jwtSection);
            var options = new JwtOptions();
            jwtSection.Bind(options);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;

                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                        ValidIssuer = options.Issuer,
                        ValidAudience = options.ValidAudience,
                        ValidateAudience = options.ValidateAudience,
                        ValidateLifetime = options.ValidateLifetime,
                        LifetimeValidator = TokenLifeTimeValidator.Validate,
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            services.AddSingleton<IJwtService, JwtService>();
        }
    }
}

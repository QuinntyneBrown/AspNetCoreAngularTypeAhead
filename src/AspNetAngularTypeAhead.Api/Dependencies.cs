using AspNetAngularTypeAhead.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace AspNetAngularTypeAhead.Api
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Asp.Net Core Angular TypeAhead",
                    Description = "",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Quinntyne Brown",
                        Email = "quinntynebrown@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });

                options.CustomSchemaIds(x => x.FullName);
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(isOriginAllowed: _ => true)
                .AllowCredentials()));

            services.AddMediatR(typeof(Startup));

            services.AddTransient<IAspNetAngularTypeAheadDbContext, AspNetAngularTypeAheadDbContext>();

            services.AddDbContext<AspNetAngularTypeAheadDbContext>(options =>
            {
                options.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"],
                    builder => builder.MigrationsAssembly("AspNetAngularTypeAhead.Api")
                        .EnableRetryOnFailure())
                .UseLoggerFactory(AspNetAngularTypeAheadDbContext.ConsoleLoggerFactory)
                .EnableSensitiveDataLogging();
            });

            services.AddControllers();
        }
    }
}

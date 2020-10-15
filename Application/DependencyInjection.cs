using Application.Services;
//using CleanArchitecture.Application.Common.Behaviours;
//using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace Target.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services.AddScoped<ITwitterService, TwitterService>();





            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .WithOrigins("http://localhost:8080")
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader());
            });


            return services;
        }
    }
}

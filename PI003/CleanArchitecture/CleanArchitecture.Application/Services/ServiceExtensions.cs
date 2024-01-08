using FluentValidation;
using Microsoft.Extensions.DependecyInjection;
using System.Reflection;


namespace CleanArchitecture.Application.Services;
    public static class ServiceExtensions{
        public static void ConfigureApplicationApp(this IserviceCollection services){
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }


using DemoApp.Core;
using DemoApp.Core.Services;
using DemoApp.Infrastructure.Identity;
using DemoApp.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp.Infrastructure.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddDependancyInjections(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IDemoContext, DemoContext>();
            services.AddScoped<JwtHandler>();

            return services;
        }
    }
}

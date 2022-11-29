using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReadGosuslugi.AppLogic;
using ReadGosuslugi.Core.Interfaces;
using ReadGosuslugi.Core.Interfaces.Applogic;
using ReadGosuslugi.Core.Logging;
using ReadGosuslugi.ExternalInterop.PayGosuslugi;
using ReadGosuslugi.Mapping;

namespace ReadGosuslugi.IoC
{
    public static class ContainerBuilder
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFinesManager, FinesManager>();
            services.AddScoped<IBillsManager, BillManager>();
            services.AddScoped<IJudicalDebtManager, JudicalDebtManager>();
            services.AddScoped<IStateDutiesManager, StateDutiesManager>();
            services.AddHttpClient<IGosuslugiPayClient, GosuslugiPayClient>();
            services.AddScoped<IComplexMapper, ComplexMapper>();
            services.AddScoped<ILogExportManager, LogExportManager>();

            return services;
        }

        public static IServiceCollection AddCustomLogging(this IServiceCollection services, IConfiguration config)
        {
            services.AddLogging(logging => 
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
                logging.AddProvider(new FileLoggerProvider(config));
            });
            return services;
        }
    }
}
